using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class PostForum
    {
        public string Id { get; set; }
        public string board { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public string author { get; set; }


        public PostForum(string _Id, string _board, string _content, DateTime _date, string _author)
        {
            this.Id = _Id;
            this.board = _board;
            this.content = _content;
            this.date = _date;
            this.author = _author;
        }

    }
}
