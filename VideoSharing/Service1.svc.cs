using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VideoSharing
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Dictionary<int, Video> videoDict = new Dictionary<int, Video>();

        public string Watch(int videoId)
        {
            if (this.videoDict.ContainsKey(videoId))
            {
                this.videoDict[videoId].views += 1;
                var str = this.videoDict[videoId].content;
                return str;
            }
            return "-1";
        }

        public void Like(int videoId)
        {
            if (this.videoDict.ContainsKey(videoId))
            {
                this.videoDict[videoId].likes += 1;
            }
        }

        public void Dislike(int videoId)
        {
            if (this.videoDict.ContainsKey(videoId))
            {
                this.videoDict[videoId].dislikes += 1;
            }
        }

        public int[] GetLikesAndDislikes(int videoId)
        {
            if (this.videoDict.ContainsKey(videoId))
            {
                return new int[2] { this.videoDict[videoId].likes, this.videoDict[videoId].dislikes };
            }
            return new int[1] { -1 };
        }

        public int GetViews(int videoId)
        {
            if (this.videoDict.ContainsKey(videoId))
            {
                return this.videoDict[videoId].views;
            }
            return -1;
        }
    }
}
