using System.Collections.Generic;

public class jQueryDataTableParamModel<T>
{
    //public DTResult() { };
    public List<T> data { get; set; }
    //
    // Summary:
    //     The draw counter that this object is a response to - from the draw parameter
    //     sent as part of the data request. Note that it is strongly recommended for security
    //     reasons that you cast this parameter to an integer, rather than simply echoing
    //     back to the client what it sent in the draw parameter, in order to prevent Cross
    //     Site Scripting (XSS) attacks.
    public int draw { get; set; }
    public string error { get; set; }
    public string Type { get; set; }
    //
    // Summary:
    //     Total records, after filtering (i.e. the total number of records after filtering
    //     has been applied - not just the number of records being returned for this page
    //     of data).
    public int recordsFiltered { get; set; }
    //
    // Summary:
    //     Total records, before filtering (i.e. the total number of records in the database)
    public int recordsTotal { get; set; }

    public int? Id { get; set; }

    public int? ModuleParamId { get; set; }
}