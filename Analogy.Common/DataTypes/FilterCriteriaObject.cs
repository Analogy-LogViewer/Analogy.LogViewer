using Analogy.Common.DataTypes;
using Analogy.CommonUtilities.ExtensionMethods;
using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    public class FilterCriteriaObject
    {
        private static FilterCriteriaObject alertFilterCriteria = new FilterCriteriaObject();
        public string[] Sources;
        public string[] ExcludedSources;
        public string[] Modules;
        public string[] ExcludedModules;
        public bool SearchEveryWhere { get; set; }
        public List<(string Field, bool Numerical)> Columns { get; set; }
        public string TextInclude { get; set; }
        public string TextExclude { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AnalogyLogLevel[]? Levels { get; set; }
        public List<FilterCriteriaUIOption> IncludeFilterCriteriaUIOptions { get; set; }
        public List<FilterCriteriaUIOption> ExcludeFilterCriteriaUIOptions { get; set; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    case '@':
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetModules(string modules)
        {
            if (string.IsNullOrEmpty(modules))
            {
                Modules = null;
                ExcludedModules = null;
            }
            else
            {
                var items = modules.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var includeItems = items.Where(i => !i.StartsWith("-"));
                var excludeItems = items.Where(i => i.StartsWith("-") && i.Length > 1)
                    .Select(i => i.Substring(1, i.Length - 1));

                Modules = includeItems.Select(val => val.Trim()).ToArray();
                ExcludedModules = excludeItems.Select(val => val.Trim()).ToArray();
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetSources(string sources)
        {
            if (string.IsNullOrEmpty(sources))
            {
                Sources = null;
                ExcludedModules = null;
            }
            else
            {
                var items = sources.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var includeItems = items.Where(i => !i.StartsWith("-"));
                var excludeItems = items.Where(i => i.StartsWith("-") && i.Length > 1)
                    .Select(i => i.Substring(1, i.Length - 1));

                Sources = includeItems.Select(val => val.Trim()).ToArray();
                ExcludedSources = excludeItems.Select(val => val.Trim()).ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetSqlExpression(bool orLogLevel)
        {
            StringBuilder sqlString = new();
            List<string> includeTexts = new() { EscapeLikeValue(TextInclude.Trim()) };

            bool orOperationInInclude = false;
            bool orOperationInExclude = false;
            var text = EscapeLikeValue(TextInclude.Trim());
            if (text.Contains('|'))
            {
                orOperationInInclude = true;
                var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (text.Contains("&") || text.Contains('+'))
            {
                var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }
            List<string> excludedTexts = new();
            if (!string.IsNullOrEmpty(TextExclude))
            {
                excludedTexts.Add(EscapeLikeValue(TextExclude.Trim()));
            }

            text = EscapeLikeValue(TextExclude.Trim());
            if (text.Contains("|"))
            {
                orOperationInExclude = true;
                var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                excludedTexts = split.Select(itm => itm.Trim()).Where(w => !string.IsNullOrEmpty(w)).ToList();
            }
            if (text.Contains("&") || text.Contains("+"))
            {
                var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                excludedTexts = split.Select(itm => itm.Trim()).ToList();
            }

            sqlString.Append("(");

            sqlString.Append(GetIncludeTextFilter(includeTexts, orOperationInInclude));

            sqlString.Append(")");

            if (excludedTexts.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(orOperationInExclude
                    ? string.Join(" and ", excludedTexts.Select(t => $" NOT Text like '%{t}%'"))
                    : string.Join(" Or ", excludedTexts.Select(t => $" NOT Text like '%{t}%'")));

                sqlString.Append(")");
            }

            if (Sources != null && Sources.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" Or ", Sources.Select(l => $" Source like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }
            if (ExcludedSources != null && ExcludedSources.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" and ", ExcludedSources.Select(l => $" NOT Source like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }
            if (ExcludedModules != null && ExcludedModules.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" and", ExcludedModules.Select(l => $" NOT Module like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }

            if (Modules != null && Modules.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" Or ", Modules.Select(l => $" Module like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }

            string andOr = orLogLevel ? "or" : "and";
            if (Levels != null && Levels.Any())
            {
                string sTemp = string.Join(",", Levels.Select(l => $"'{l}'"));
                sqlString.Append($" {andOr} Level in (" + sTemp + ")");
            }

            string dateFilter = $" AND (Date >= '{StartTime}' and Date <= '{EndTime}')";

            sqlString.Append(dateFilter);

            if (includeTexts.Any() && !SearchEveryWhere)
            {
                var includeColumns = IncludeFilterCriteriaUIOptions.Where(f => f.CheckMember);
                foreach (FilterCriteriaUIOption include in includeColumns)
                {
                    sqlString.Append(" or (");
                    string op = (orOperationInInclude) ? "or" : "and";
                    sqlString.Append(string.Join($" {op} ",
                        includeTexts.Select(l =>
                            $" [{EscapeLikeValue(include.ValueMember)}] like '%{EscapeLikeValue(l)}%'")));
                    sqlString.Append(")");
                }
            }

            if (excludedTexts.Any())
            {
                var excludeColumns = ExcludeFilterCriteriaUIOptions.Where(f => f.CheckMember);
                foreach (FilterCriteriaUIOption exclude in excludeColumns)
                {
                    sqlString.Append(" and (");
                    string op = (orOperationInExclude) ? "and" : "or";
                    sqlString.Append(string.Join($" {op} ",
                        excludedTexts.Select(l =>
                            $" NOT [{EscapeLikeValue(exclude.ValueMember)}] like '%{EscapeLikeValue(l)}%'")));
                    sqlString.Append(")");
                }
            }

            return sqlString.ToString();
        }

        private string GetIncludeTextFilter(List<string> includeTexts, bool orOperationInInclude)
        {
            IEnumerable<string> GenerateSingleCombinationPerColumn(string field, bool numerical)
            {
                foreach (string text in includeTexts)
                {
                    if (numerical)
                    {
                        if (!string.IsNullOrEmpty(text) && int.TryParse(text, out var number))
                        {
                            yield return $" {field} = {number}";
                        }
                    }
                    else
                    {
                        yield return $" {field} like '%{text}%'";
                    }
                }
            }

            if (SearchEveryWhere)
            {
                var allValidCombinations =
                    Columns.Select(c => GenerateSingleCombinationPerColumn(c.Field, c.Numerical).ToList());
                var entries = allValidCombinations.Where(c => c.Any()).Select(c =>
                    string.Join(orOperationInInclude ? " Or " : " and ", c));
                var combined = string.Join(" Or ", entries);
                return combined;
            }
            else
            {
                var includeTextFinal = orOperationInInclude
                    ? string.Join(" Or ", GenerateSingleCombinationPerColumn("Text", false))
                    : string.Join(" and ", GenerateSingleCombinationPerColumn("Text", false));
                return includeTextFinal;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Match(string rowLine, string criteria, PreDefinedQueryType type)
        {
            if (string.IsNullOrEmpty(criteria))
            {
                return false;
            }

            List<string> includeTexts = new List<string>(1) { criteria.Trim() };

            bool orOperationInInclude = false;
            if (criteria.Contains('|'))
            {
                orOperationInInclude = true;
                var split = criteria.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (criteria.Contains("&") || criteria.Contains('+'))
            {
                var split = criteria.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (orOperationInInclude)
            {
                switch (type)
                {
                    case PreDefinedQueryType.Contains:
                        return includeTexts.Any(t =>
                            rowLine.Contains(t, StringComparison.InvariantCultureIgnoreCase) &&
                            !string.IsNullOrEmpty(t));
                    case PreDefinedQueryType.Equals:
                        return includeTexts.Any(t =>
                            rowLine.Equals(t, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(t));
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
            else
            {
                switch (type)
                {
                    case PreDefinedQueryType.Contains:
                        return includeTexts.All(t => rowLine.Contains(t, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(t));
                    case PreDefinedQueryType.Equals:
                        return includeTexts.All(t => rowLine.Equals(t, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(t));
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }

        public static bool MatchAlert(AnalogyLogMessage analogyLogMessage, PreDefineAlert preDefineAlert)
        {
            alertFilterCriteria.SetModules(preDefineAlert.Modules);
            alertFilterCriteria.SetSources(preDefineAlert.Sources);
            alertFilterCriteria.TextInclude = preDefineAlert.IncludeText ?? string.Empty;
            alertFilterCriteria.TextExclude = preDefineAlert.ExcludeText ?? string.Empty;
            return alertFilterCriteria.MatchAlert(analogyLogMessage);
        }

        private bool MatchAlert(AnalogyLogMessage message)
        {
            bool match = true;
            if (!string.IsNullOrEmpty(TextInclude))
            {
                match = message.Text.Contains(TextInclude, StringComparison.InvariantCultureIgnoreCase);
            }

            if (!match)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(TextExclude))
            {
                match = !message.Text.Contains(TextExclude, StringComparison.InvariantCultureIgnoreCase);
            }

            if (!match)
            {
                return false;
            }

            if (Modules != null && Modules.Any())
            {
                match = Modules.Any(m => message.Module.Contains(m, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!match)
            {
                return false;
            }

            if (ExcludedModules != null && ExcludedModules.Any())
            {
                match = ExcludedModules.All(m => !message.Module.Contains(m, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!match)
            {
                return false;
            }

            if (Sources != null && Sources.Any())
            {
                match = Sources.Any(s => message.Source.Contains(s, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!match)
            {
                return false;
            }

            if (ExcludedSources != null && ExcludedSources.Any())
            {
                match = ExcludedSources.All(s => !message.Module.Contains(s, StringComparison.InvariantCultureIgnoreCase));
            }

            return match;
        }
    }
}