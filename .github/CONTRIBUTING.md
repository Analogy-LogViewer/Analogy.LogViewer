# Contributing to Analogy Log Viewer

We'd love for you to contribute to our source code! Here are the guidelines we'd like you to follow:

 - [Question or Problem?](#question)
 - [Issues and Bugs](#issue)
 - [Feature Requests](#feature)
 - [Submission Guidelines](#submit)
 - [Further Info](#info)

## <a name="question"></a> Got a Question or Problem?

If you have questions about how to use this tool, please feel free to contact me at [Lior Banai](mailto:liorbanai@gmail.com)


## <a name="issue"></a> Found an Issue?

If you find a bug in the source code or a mistake in the documentation, you can help us by submitting an issue to [Github Repository][github]. Even better you can submit a Pull Request with a fix.

**Please see the [Submission Guidelines](#submit) below.**

## <a name="feature"></a> Want a Feature?

You can request a new feature by submitting an issue to our [Github Repository][github]. If you would like to implement a new feature then consider creating it in new branch and run the unit tests suite to verify nothing is broken.

## <a name="submit"></a> Submission Guidelines

### Submitting an Issue
Before you submit your issue search the archive, maybe your question was already answered.

If your issue appears to be a bug, and hasn't been reported, open a new issue. Help us to maximize the effort we can spend fixing issues and adding new features, by not reporting duplicate issues. Providing the following information will increase the chances of your issue being dealt with quickly:

* **Overview of the Issue** - if an error is being thrown a non-minified stack trace helps
* **Motivation for or Use Case** - explain why this is a bug for you
* **Forest Version(s)** - is it a regression?
* **Reproduce the Error** - try to describe how to reproduce the error
* **Related Issues** - has a similar issue been reported before?
* **Suggest a Fix** - if you can't fix the bug yourself, perhaps you can point to what might be
  causing the problem (line of code or commit)

### Submitting a Merge Request
Before you submit your merge request consider the following guidelines:

* Make your changes in a new git branch.
* Create your patch, **including appropriate test cases**.
* Run the test suite and ensure that all tests pass.
* Add a line in the CHANGELOG.md under Unreleased. This will be used form generating the release notes.
* Commit your changes using a descriptive commit message.
* Build your changes locally to ensure all the tests pass
* Push your branch to Github

In Github, send a pull request to original master branch.
If we suggest changes, then:

* Make the required updates.
* Re-run the test suite to ensure tests are still passing.
* Commit your changes to your branch (e.g. `my-fix-branch`).
* Push the changes to your Github repository (this will update your Pull Request).

If the PR gets too outdated we may ask you to rebase and force push to update the PR:

_WARNING: Squashing or reverting commits and force-pushing thereafter may remove Github comments on code that were previously made by you or others in your commits. Avoid any form of rebasing unless necessary._

That's it! Thank you for your contribution!

#### After your merge request is merged

After your pull request is merged, you can safely delete your branch and pull the changes
from the main (upstream) repository.

## <a name="info"></a> Info

For more info, please reach out to me at [Lior Banai](mailto:liorbanai@gmail.com)

[contribute]: CONTRIBUTING.md
[github]: https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues 

