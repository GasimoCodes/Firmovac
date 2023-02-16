namespace Firmovac.DataDefinitions
{
    /// <summary>
    /// Definition of a single user-defined column
    /// </summary>
    public class ColumnDefinition
    {
        public int Id { get; set; }
        public bool isHidden { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }



    }
}
