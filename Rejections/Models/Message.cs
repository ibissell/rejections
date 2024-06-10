using System;
using System.Collections.Generic;

namespace Rejections.Models;

/// <summary>
/// Contains Messages that have been sent or received by the Trust Intergration Engine
/// 
/// Rhapsody:
/// TGHRHAPSODY &gt; PRODUCTION &gt; # Active Communication Points &gt; Message Repository
/// TGHRHAPSODY &gt; PRODUCTION &gt; Lorenzo &gt; Lorenzo_In_B2_Handles ACK &gt; Read Original Message
/// 
/// SSRS:
/// TGHDATAWARE &gt; Rhapsody &gt; Lorenzo Rejections By Week and Department
/// 
/// Applications:
/// Lorenzo Rejections
/// 
/// </summary>
public partial class Message
{
    public int Id { get; set; }

    public string? SendingApplication { get; set; }

    public string? ReceivingApplication { get; set; }

    public string? MessageType { get; set; }

    public string? TriggerEvent { get; set; }

    public DateTime? MessageDttm { get; set; }

    public string? MessageControlId { get; set; }

    public int? SequenceNo { get; set; }

    public string? Message1 { get; set; }

    public DateTime InsertDttm { get; set; }
}
