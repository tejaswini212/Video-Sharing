using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VideoSharing
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Watch(int videoId);
        [OperationContract]
        void Like(int videoId);
        [OperationContract]
        void Dislike(int videoId);
        [OperationContract]
        int[] GetLikesAndDislikes(int videoId);
        [OperationContract]
        int GetViews(int videoId);
    }


    
    [DataContract]
    public class Video
    {
        public int videoId;
        public string content;
        public int likes;
        public int dislikes;
        public int views;

        public Video(int id, string video)
        {
            this.videoId = id;
            this.content = video;
        }
    }
}
