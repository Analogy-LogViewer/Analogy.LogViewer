//using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Analogy.DataTypes
{
    public enum MainFormType
    {
        RibbonForm, //classic pre V5
        FluentForm,
    }

    public enum ApplicationSettingsSelectionType
    {
        ApplicationGeneralSettings,
        ApplicationUISettings,
        MessagesFilteringSettings,
        MessagesLayoutSettings,
        ColorSettings,
        ColorHighlighting,
        PredefinedQueriesSettings,
        ShortcutsSettings,
        ExtensionsSettings,
        UpdatesSettings,
        DebuggingSettings,
        DataProvidersSettings,
        RealTimeDataProvidersSettings,
        FilesAssociationSettings,
        ExternalLocationsSettings,
        DonationsSettings,
        AdvancedModeSettings,
    }
    public enum ApplicationWelcomeSelectionType
    {
        General,
        Theme,
        DataProvides,
        Extensions,
        GlobalTools,
        WhatIsNew,
        ShareAndSupport,
        Feedback,
    }
}