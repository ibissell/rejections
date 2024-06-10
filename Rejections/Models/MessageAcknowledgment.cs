using System;
using System.Collections.Generic;

namespace Rejections.Models;

/// <summary>
/// Contains acknowledgment data that has been sent or received by the Trust Intergration Engine associated with a Message
/// 
/// Rhapsody:
/// TGHRHAPSODY &gt; PRODUCTION &gt; # Active Communication Points &gt; Message Repository
/// 
/// SSRS:
/// TGHDATAWARE &gt; Rhapsody &gt; Lorenzo Rejections By Week and Department
/// 
/// Applications:
/// Lorenzo Rejections
/// </summary>
public partial class MessageAcknowledgment
{
    public int Id { get; set; }

    public int MessageId { get; set; }

    public string? MessageControlId { get; set; }

    public string? AcknowledgementCode { get; set; }

    public string? TextMessage { get; set; }
}
