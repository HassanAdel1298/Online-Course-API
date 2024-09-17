using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class ALlSessionDTO
    {
        public int Session_ID { get; set; }

        public string SessionName { get; set; }

        
        public DateTime Start_Date { get; set; }

       
        public DateTime End_at { get; set; }

        public float Rate { get; set; }

        public String OnlineVideo { get; set; }

        public String Zoom { get; set; }


        public int Group_ID { get; set; }
    }
}
