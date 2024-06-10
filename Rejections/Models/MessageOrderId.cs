using System;
using System.Collections.Generic;

namespace Rejections.Models;

public partial class MessageOrderId
{
    public int Id { get; set; }

    public int MessageId { get; set; }

    public string? OrderId { get; set; }

    public string? Idtype { get; set; }

    public string? PlacerFiller { get; set; }
}
