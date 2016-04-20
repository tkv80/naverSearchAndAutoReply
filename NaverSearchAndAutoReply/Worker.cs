using System;
using System.ComponentModel;
using System.Threading;

namespace NaverSearch
{
    internal class Worker : BackgroundWorker
    {
        public Worker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public int Interval { private get; set; }
        public string Comment { private get; set; }
        public string Cookie { private get; set; }
        public bool OneTime { private get; set; }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!this.CancellationPending)
            {
                string message;
                var html = HttpClient.GetHtml(Cookie);
                var searchText =
                    html.Substring(
                        "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"board-box\" style=\"table-layout:fixed\">",
                        "</form>");

                var articleId = searchText.Substring("articleid=", "&");
                var title = searchText.Substring(" class=\"m-tcol-c\">", "</a>");

                var time = searchText.Substring("<td class=\"view-count m-tcol-c\">", "</td>");

                if (time.Split(':').Length == 2)
                {
                    var hour = time.Split(':')[0];
                    var minute = time.Split(':')[1];

                    if (DateTime.Now.Hour.ToString("00") == hour && DateTime.Now.Minute.ToString("00") == minute)
                    {
                        message = string.Format("{0}|{1} {2}", "마캠", time, title);
                        HttpClient.CommentPost(Cookie, Comment, articleId);
                        new GcmManager().SendNotification(message, "캠핑예약");

                        if (OneTime)
                        {
                            CancelAsync();
                        }
                        
                        Thread.Sleep(1000*120);
                    }
                }

                message = string.Format("{0} {1} {2}", "실패", time, title);

                ReportProgress(0, message);
                Thread.Sleep(1000 * Interval);
            }
        }
    }
}
