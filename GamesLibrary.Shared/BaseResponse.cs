using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GamesLibrary.Shared;

public class BaseResponse
{
    public bool Error { get; set; }
    public string? Message { get; set; }
}
