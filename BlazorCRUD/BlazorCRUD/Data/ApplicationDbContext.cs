using SYS = System;
using MSEFC = Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Data
{
  /// <summary>
  /// This class initializes the database context and any related data sets within the context.
  /// </summary>
  [SYS.Serializable]
  public class ApplicationDbContext : MSEFC.DbContext
  {
    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="ApplicationDbContext"/>
    /// using the given options.
    /// </summary>
    /// <param name="options">Database context options.</param>
    public ApplicationDbContext( MSEFC.DbContextOptions<ApplicationDbContext> options )
      : base( options )
    {
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets <see cref="EmployeeInfo"/> objects in the context.
    /// </summary>
    public MSEFC.DbSet<EmployeeInfo> Employees { get; set; }

    #endregion
  }
}
