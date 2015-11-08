using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Connect4.Core;

namespace Connect4.Controllers
{
    public class GameController : ApiController
    { 
        public const int SIZE = 4;
        public static Board broad = new Board(SIZE);

        [HttpPost]
        public void Start()
        {
            broad = new Board(SIZE);
        }

        [HttpGet]
        public int DropDiskAt(int col, int player)
        {
            var row = broad.DropDiskAt(col, player);
            if (row == -1)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Column {0} is full", col))
                });
            }

            return row;
        }

        [HttpGet]
        public bool CheckIfWin(int col, int row, int player)
        {
            return broad.CheckIfWin(col, row, player);
        }
    }
}
