namespace FreelanceApp.API.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;

        public int PageNumber{get; set;} = 1;
        
        private int pageSize = 10 ;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ; }
        }

        public int UserId {get; set;}

        public int minExperience {get; set;}  = 1; 
        
        public int maxExperience {get; set;}  = 25;

        public string OrderBy {get; set;}

        public bool Likees {get; set;} = false;

        public bool Likers {get; set;} = false;
     }
}