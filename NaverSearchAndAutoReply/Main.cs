using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace NaverSearch
{
    public partial class Main : Form
    {
        private readonly Worker _worker = new Worker();
        private string _cookie;


        private string step = "";

        public Main()
        {
            InitializeComponent();
            numDelay.Value = 10;
            cbOntime.Checked = true;
            btnStart.Enabled = false;

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Url =
                new Uri(
                    "http://nid.naver.com/nidlogin.login?mode=form&url=http%3A%2F%2Fcafe.naver.com%2FArticleList.nhn%3Fsearch.clubid%3D24392788%26search.menuid%3D75%26search.boardtype%3DL%26search.clubid%3D24392788");

            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.AbsoluteUri.Contains("nidlogin.login") && step == "")
            {
                webBrowser1.Document.GetElementById("id")
                    .SetAttribute("value", "tkv80");
                webBrowser1.Document.GetElementById("pw")
                    .SetAttribute("value", "taekown8080");
                webBrowser1.Document.Forms["frmNIDLogin"].InvokeMember("submit");
                step = "login";
            }
            else if (e.Url.AbsoluteUri ==
                     "http://cafe.naver.com/ArticleList.nhn?search.clubid=24392788&search.menuid=75&search.boardtype=L&search.clubid=24392788&search.clubid=24392788")
            {
                Thread.Sleep(1000);

                _cookie = webBrowser1.Document.Cookie;

                Logging("준비완료!!");
                btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
                btnStart.Text = @"중지 증...";
                btnStart.Enabled = false;
            }
            else
            {
                _worker.Interval = (int) numDelay.Value;
                _worker.Comment = txtComment.Text;
                _worker.Cookie = _cookie;

                _worker.OneTime = cbOntime.Checked;
                _worker.RunWorkerAsync();

                btnStart.Text = @"중지";
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (txtLog.Lines.Length <= 50)
            {
                Logging(e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                Logging(e.UserState.ToString());
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logging("완료~!!");
            btnStart.Enabled = true;
            btnStart.Text = @"시작";
        }

        private void Logging(string log)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}\r\n", log));
        }

        private void Logging(string log, Color color)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, color, string.Format(" - {0}\r\n", log));
        }

        private void Logging(string log, string log1, Color color)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}", log));
            AppendText(txtLog, color, string.Format(" - {0}\r\n", log1));
        }

        private void Logging(string log, string error)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}", log));
            AppendText(txtLog, Color.Red, string.Format(" - {0}\r\n", error));
        }

        private void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }
    }
}