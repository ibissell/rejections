using System;
using System.Collections.Generic;

namespace Rejections.Models;

public partial class MessagePatientId
{
    public int Id { get; set; }

    public int? MessageId { get; set; }

    public string? PatientId { get; set; }

    public string? Idtype { get; set; }
}
