using System.IO;
using System.Net;
using System.Text;

namespace NaverSearch
{
    static class HttpClient
    {

        public static string GetHtml(string cookie)
        {
            var cookieSplit = cookie.Split(';');

            var httpWRequest = (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/ArticleList.nhn?search.clubid=24392788&search.menuid=75&search.boardtype=L&search.clubid=24392788&search.clubid=24392788");
            httpWRequest.Accept = "/*/";
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                "http://cafe.naver.com/mycampingmarket.cafe?iframe_url=/ArticleList.nhn%3Fsearch.clubid=24392788%26search.menuid=75%26search.boardtype=L%26search.clubid=24392788";

            httpWRequest.CookieContainer = new CookieContainer();

            foreach (var s in cookieSplit)
            {
                //npic=+v6qFTZsanuPjE91OTODa10/5L8GyS+ucLnEc3/7WRxLblUrPx/uy8Z37y5iwMttCA==
                var key = s.Substring(0, s.IndexOf("="));
                var value = s.Substring(s.IndexOf("=") + 1, s.Length - key.Length - 1).Trim();

                httpWRequest.CookieContainer.Add(new Cookie(key.Trim(), value.Trim(), "/", "cafe.naver.com"));
            }

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));
            var resultHtml = sr.ReadToEnd();

            return resultHtml;
        }

        public static string CommentPost(string cookie, string comment, string articleId)
        {
            var parameter = string.Format("content={0}&clubid=24392788&articleid={1}&m=write&&emotion=2831069&orderby=asc&branchCode=GKPlOPjKZksoLEE320txMR%2Fr7QD07qYeDC8qr%2BYXG4s%3D&", System.Web.HttpUtility.UrlEncode(comment, Encoding.GetEncoding("euc-kr")), articleId);

            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/CommentPost.nhn");
            httpWRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.Host = "cafe.naver.com";
            httpWRequest.Referer = string.Format("http://cafe.naver.com/ArticleRead.nhn?clubid=24392788&articleid={0}&networkMemberId=tkv80&networkSearchKey=Article&networkSearchType=7&networkSearchPage=1", articleId);
            httpWRequest.KeepAlive = true;

            httpWRequest.Method = "Post";

            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.CookieContainer = new CookieContainer();

            foreach (var s in cookieSplit)
            {
                var key = s.Substring(0, s.IndexOf("="));
                var value = s.Substring(s.IndexOf("=") + 1, s.Length - key.Length - 1).Trim();

                httpWRequest.CookieContainer.Add(new Cookie(key.Trim(), value.Trim(), "/", "cafe.naver.com"));
            }

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();
            return resultHtml;
        }
    }
}
