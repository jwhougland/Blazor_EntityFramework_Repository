using SYS = System;
using SCD = System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Data
{
  /// <summary>
  /// This class defines the data associated with an employee.
  /// </summary>
  [SYS.Serializable]
  public class EmployeeInfo
  {
    #region Public properties

    /// <summary>
    /// Gets or sets a unique numerical identifier for an employee.
    /// </summary>
    [SCD.Key]
    public int EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets an employee's name.
    /// </summary>
    [SCD.Required]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the city an employee lives in.
    /// </summary>
    [SCD.Required]
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the country an employee lives in.
    /// </summary>
    [SCD.Required]
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets the employee's gender.
    /// </summary>
    public string Gender { get; set; }

    #endregion
  }
}
