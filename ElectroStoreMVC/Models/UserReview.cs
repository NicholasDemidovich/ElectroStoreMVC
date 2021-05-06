using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.Models
{
    public class UserReview
    {
        public int UserReviewId { get; set; }
        public string UserReviewContext { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        
    }
}
