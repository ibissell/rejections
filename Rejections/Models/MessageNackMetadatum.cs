using System;
using System.Collections.Generic;

namespace Rejections.Models;

/// <summary>
/// Contains a generic description and the cause/resolution of NACK Messages. Manually updated.
/// 
/// SSRS:
/// TGHDATAWARE &gt; Rhapsody &gt; Lorenzo Rejections By Week and Department
/// 
/// Applications:
/// Lorenzo Rejections
/// </summary>
public partial class MessageNackMetadatum
{
    public int Id { get; set; }

    public string SendingApplication { get; set; } = null!;

    public string ErrorCode { get; set; } = null!;

    public string? Description { get; set; }

    public string? Cause { get; set; }

    public string? Resolution { get; set; }

    public DateTime InsertDttm { get; set; }

    public DateTime? UpdateDttm { get; set; }
}
