using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideoSharingTryIT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        Uri webUrl = new Uri("http://webstrar53.fulton.asu.edu/page2/");
        //Uri webUrl = new Uri("https://localhost:44302/");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = webUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        //On get video button click call video api
        protected void GetVideoButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage responseMessage = client.GetAsync(webUrl.AbsoluteUri + "api/Video/" + inputVideoIDText.Text.ToString()).Result;
            Video result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<Video>().Result;
                outputStatusLabel.Text = $"Number of people viewed this video {result.VideoId.ToString()} is {result.Views.ToString()}";
            }

            return;
        }

        //On like video button click call video api
        protected void LikeButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage responseMessage = client.GetAsync(webUrl.AbsoluteUri + "api/Video/Like/" + inputVideoIDText.Text.ToString()).Result;
            string result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<string>().Result;
                LikeLabel.Text = $"Video {inputVideoIDText.Text.ToString()} is liked.";
            }

            return;
        }

        //On dislike video button click call video api
        protected void DislikeButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage responseMessage = client.GetAsync(webUrl.AbsoluteUri + "api/Video/DisLike/" + inputVideoIDText.Text.ToString()).Result;
            string result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<string>().Result;
                DislikeLabel.Text = $"Video {inputVideoIDText.Text.ToString()} is disliked.";
            }

            return;
        }

        //On get count of likes and dislike video button click call video api and display count of total number of likes and dislikes
        protected void GetLikeDislikeButton_Click(object sender, EventArgs e)
        {
            HttpResponseMessage responseMessage = client.GetAsync(webUrl.AbsoluteUri + "api/Video/GetLikesAndDislikes/" + inputVideoIDText.Text.ToString()).Result;
            string[] result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsAsync<string[]>().Result;
                LikeLabel_All.Text = $"Total number of like: {result[0]}";
                DislikeLabel_All.Text = $"Total number of dislike: {result[1]}";
            }

            return;
        }
    }
}