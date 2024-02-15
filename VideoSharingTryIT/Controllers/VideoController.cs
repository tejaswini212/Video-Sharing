using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace VideoSharingTryIT
{
    public class VideoController : ApiController
    {
        //Define dectionary to hold values of videoID and Video
        private Dictionary<int, Video> videoDict = new Dictionary<int, Video>();
        //Initialize constructor of video controller
        public VideoController()
        {
            DeserializeVideoDictionary();
        }


        //Add count of watch to the dictionary
        public int Watch(int videoId)
        {
            DeserializeVideoDictionary();
            if (this.videoDict.ContainsKey(videoId))
            {
                int val = this.videoDict[videoId].Views += 1;
                SerializeVideoDictionary();
                return val;
            }

            return -1;
        }

        //Add count of like to the dictionary
        [HttpGet]
        [Route("api/Video/Like/{videoId}")]
        public string Like(string videoId)
        {
            DeserializeVideoDictionary();
            int vidId = Int32.Parse(videoId);
            if (this.videoDict.ContainsKey(vidId))
            {
                this.videoDict[vidId].Likes += 1;
                SerializeVideoDictionary();
                return this.videoDict[vidId].Likes.ToString();
            }

            return "0";
        }

        //Add count of dislike to the dictionary
        [HttpGet]
        [Route("api/Video/Dislike/{videoId}")]
        public string Dislike(int videoId)
        {
            DeserializeVideoDictionary();
            if (this.videoDict.ContainsKey(videoId))
            {
                this.videoDict[videoId].Dislikes += 1;
                SerializeVideoDictionary();
                return this.videoDict[videoId].Likes.ToString();
            }

            return "0";
        }

        //Get count of likes and dislikes from the dictionary
        [HttpGet]
        [Route("api/Video/GetLikesAndDislikes/{videoId}")]
        public string[] GetLikesAndDislikes(int videoId)
        {
            DeserializeVideoDictionary();
            if (this.videoDict.ContainsKey(videoId))
            {
                SerializeVideoDictionary();
                return new string[2] { this.videoDict[videoId].Likes.ToString(), this.videoDict[videoId].Dislikes.ToString() };
            }
            return new string[2] { "0", "0" };
        }

        //Get views of the video
        public int GetViews(int videoId)
        {
            DeserializeVideoDictionary();
            if (this.videoDict.ContainsKey(videoId))
            {
                SerializeVideoDictionary();
                return this.videoDict[videoId].Views;
            }
            return -1;
        }

        // GET api/<controller>/5
        public Video Get(int id)
        {
            DeserializeVideoDictionary();
            if (!this.videoDict.ContainsKey(id))
            {
                this.videoDict.Add(id, new Video(id));
            }
            this.videoDict[id].Views++;
            SerializeVideoDictionary();
            return this.videoDict[id];
        }

        //Serialize video dictionary to store in json
        public void SerializeVideoDictionary()
        {
            // Serialize the dictionary to a JSON object
            var json = this.videoDict;
            string jsonString = JsonConvert.SerializeObject(json);

            // Write the JSON string to a file with the same name but .json extension
            string outFileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            string outFileName = Path.ChangeExtension("videoDictionary", ".json");
            //string outFileLocation = Path.Combine(fLocation, outFileName);
            outFileLocation = Path.Combine(outFileLocation, outFileName);
            File.WriteAllText(outFileLocation, jsonString);
        }

        //Deserialize video dictionary to get data from json
        public void DeserializeVideoDictionary()
        {
            string inFileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            string inFileName = Path.ChangeExtension("videoDictionary", ".json");
            //string outFileLocation = Path.Combine(fLocation, outFileName);
            inFileLocation = Path.Combine(inFileLocation, inFileName);
            string videoInfo = File.ReadAllText(inFileLocation);
            this.videoDict = JsonConvert.DeserializeObject<Dictionary<int, Video>>(videoInfo);
        }
    }
}