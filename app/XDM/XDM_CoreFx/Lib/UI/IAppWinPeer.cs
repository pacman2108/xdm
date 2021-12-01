﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XDM.Common.UI;
using XDM.Core.Lib.Common;

namespace XDM.Core.Lib.UI
{
    public interface IAppWinPeer
    {
        IEnumerable<FinishedDownloadEntry> FinishedDownloads { get; set; }

        IEnumerable<InProgressDownloadEntry> InProgressDownloads { get; set; }

        IInProgressDownloadRow? FindInProgressItem(string id);

        IFinishedDownloadRow? FindFinishedItem(string id);

        IList<IInProgressDownloadRow> SelectedInProgressRows { get; }

        IList<IFinishedDownloadRow> SelectedFinishedRows { get; }

        IButton NewButton { get; }

        IButton DeleteButton { get; }

        IButton PauseButton { get; }

        IButton ResumeButton { get; }

        IButton OpenFileButton { get; }

        IButton OpenFolderButton { get; }

        void AddToTop(InProgressDownloadEntry entry);

        void AddToTop(FinishedDownloadEntry entry);

        void SwitchToInProgressView();

        void ClearInProgressViewSelection();

        void SwitchToFinishedView();

        void ClearFinishedViewSelection();

        bool Confirm(object? window, string text);

        void ConfirmDelete(string text, out bool approved, out bool deleteFiles);

        IDownloadCompleteDialog CreateDownloadCompleteDialog(IApp app);

        INewDownloadDialogSkeleton CreateNewDownloadDialog(bool empty);

        INewVideoDownloadDialog CreateNewVideoDialog();

        IProgressWindow CreateProgressWindow(string downloadId, IApp app, IAppUI appUI);

        void RunOnUIThread(Action action);

        void RunOnUIThread(Action<string, int, double, long> action, string id, int progress, double speed, long eta);

        bool IsInProgressViewSelected { get; }

        void Delete(IInProgressDownloadRow row);

        void Delete(IFinishedDownloadRow row);

        void DeleteAllFinishedDownloads();

        void Delete(IEnumerable<IInProgressDownloadRow> rows);

        void Delete(IEnumerable<IFinishedDownloadRow> rows);

        string GetUrlFromClipboard();

        AuthenticationInfo? PromtForCredentials(string message);

        void ShowUpdateAvailableNotification();

        void ShowMessageBox(object? window, string message);

        void OpenNewDownloadMenu();

        IMenuItem[] MenuItems { get; }

        Dictionary<string, IMenuItem> MenuItemMap { get; }

        string? SaveFileDialog(string? initialPath);

        void ShowRefreshLinkDialog(InProgressDownloadEntry entry, IApp app);

        void SetClipboardText(string text);

        void SetClipboardFile(string file);

        void ShowPropertiesDialog(BaseDownloadEntry ent, ShortState? state);

        void ShowYoutubeDLDialog(IAppUI appUI, IApp app);

        DownloadSchedule? ShowSchedulerDialog(DownloadSchedule schedule);

        void ShowBatchDownloadWindow(IApp app, IAppUI appUi);

        void ShowSettingsDialog(IApp app, int page = 0);

        void ImportDownloads(IApp app);

        void ExportDownloads(IApp app);

        void UpdateBrowserMonitorButton();

        void ShowBrowserMonitoringDialog(IApp app);

        void UpdateParallalismLabel();

        IUpdaterUI CreateUpdateUIDialog(IAppUI ui);

        void ClearUpdateInformation();

        IQueuesWindow CreateQueuesAndSchedulerWindow(IAppUI appUi);

        IQueueSelectionDialog CreateQueueSelectionDialog();

        event EventHandler<CategoryChangedEventArgs> CategoryChanged;

        event EventHandler InProgressContextMenuOpening;

        event EventHandler FinishedContextMenuOpening;

        event EventHandler SelectionChanged;

        event EventHandler NewDownloadClicked;

        event EventHandler YoutubeDLDownloadClicked;

        event EventHandler BatchDownloadClicked;

        event EventHandler SettingsClicked;

        event EventHandler ClearAllFinishedClicked;

        event EventHandler ExportClicked;

        event EventHandler ImportClicked;

        event EventHandler BrowserMonitoringButtonClicked;

        event EventHandler BrowserMonitoringSettingsClicked;

        event EventHandler UpdateClicked;

        event EventHandler HelpClicked;

        event EventHandler SupportPageClicked;

        event EventHandler BugReportClicked;

        event EventHandler CheckForUpdateClicked;

        event EventHandler SchedulerClicked;

        event EventHandler MoveToQueueClicked;
    }

    public class CategoryChangedEventArgs : EventArgs
    {
        public int Level { get; set; }
        public int Index { get; set; }
        public Category? Category { get; set; }
    }
}
