using System;
using System.Collections.Generic;

namespace Rejections.Models;

public partial class MessageOrder
{
    public int Id { get; set; }

    public int MessageId { get; set; }

    public string? ExamCode { get; set; }

    public string? ExamDescription { get; set; }

    public DateTime? QuantityTimingStartDttm { get; set; }
}
