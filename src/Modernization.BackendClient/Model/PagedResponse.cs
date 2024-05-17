using System.Collections.Generic;

namespace Modernization.BackendClient.Model;

public class PagedResponse<T>
{
    public List<T> Results { get; set; }

    public int TotalRecordCount { get; set; }
}