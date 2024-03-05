using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfuQotd.Shared;

public class QotdAppSettings
{
    public required string ExternalQotdServiceUri { get; init; }
}