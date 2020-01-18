using SYS = System;
using SCG = System.Collections.Generic;
using System.Linq;

namespace BlazorCRUD.Data
{
  [SYS.Serializable]
  public class EmployeeService
  {
    #region Private constants

    /// <summary>
    /// Holds the status message for when an employee is successfully saved to the database.
    /// </summary>
    private const string CreateUpdateSuccessMessage = "Employee saved successfully";

    /// <summary>
    /// Holds the status message for when an employee is not saved to the database successfully.
    /// </summary>
    private const string CreateUpdateFailureMessage = "An error occured saving the employee.  Please try again later.";

    /// <summary>
    /// Holds the status message for when an employee's info is successfully deleted.
    /// </summary>
    private const string DeleteSuccessMessage = "Employee info deleted successfully.";

    /// <summary>
    /// Holds the status message for when an employee's info is not deleted from the database successfully.
    /// </summary>
    private const string DeleteFailureMessage = "An error occurred deleting the employee's info.  Please try again later.";

    #endregion

    #region Private member objects

    /// <summary>
    /// Provides access to the application database context.
    /// </summary>
    private readonly ApplicationDbContext m_dbContext;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a fully initialized <see cref="EmployeeService"/>
    /// using the given database context.
    /// </summary>
    /// <param name="dbContext">Provides access to the application data context.</param>
    public EmployeeService( ApplicationDbContext dbContext )
    {
      m_dbContext = dbContext;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Returns a list of employee in the data context.
    /// </summary>
    /// <returns>See method description.</returns>
    public SCG.List<EmployeeInfo> GetEmployees() => 
      m_dbContext.Employees.ToList();

    /// <summary>
    /// Adds an employee to the data context, and then saves the data context.
    /// </summary>
    /// <param name="employee"></param>
    /// <returns>A success or failure status message.</returns>
    public string Create( EmployeeInfo employee )
    {
      try
      {
        // Attempt to add the employee to the context and save changes.
        m_dbContext.Add( employee );
        m_dbContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report that there has been a failure.
        return CreateUpdateFailureMessage;
      }      

      // Report that the employee record creation worked.
      return CreateUpdateSuccessMessage;
    }

    /// <summary>
    /// This method queries the data context for an employee whose ID matches
    /// the given ID, and that employee's record is returned.
    /// </summary>
    /// <param name="id">Primary key for an employee record.</param>
    /// <returns>See method description.</returns>
    public EmployeeInfo GetEmployeeById( int id ) => 
      m_dbContext.Employees.First( obj => obj.EmployeeId == id );  
    
    /// <summary>
    /// This method updates an employee record in the database
    /// with the given employee information.
    /// </summary>
    /// <param name="employee">Data to update in the database.</param>
    /// <returns>A success or failure status message.</returns>
    public string UpdateEmployee( EmployeeInfo employee )
    {
      try
      {
        // Attempt to update the employee record in the context and
        // persist the changes to the database.
        m_dbContext.Employees.Update( employee );
        m_dbContext.SaveChanges();
      }
      catch ( SYS.Exception )
      {
        // Report that there has been a failure.
        return CreateUpdateFailureMessage;
      }

      // Report that the employee record update worked.
      return CreateUpdateSuccessMessage;
    }

    /// <summary>
    /// This method deletes the given employee object's info from the database.
    /// </summary>
    /// <param name="employee">Indicates which employee's info requires deletion.</param>
    /// <returns>A success or failure message.</returns>
    public string DeleteEmployeeInfo( EmployeeInfo employee )
    {
      try
      {
        m_dbContext.Remove( employee );
        m_dbContext.SaveChanges();
      }
      catch (SYS.Exception)
      {
        // Report that there has been a failure.
        return DeleteFailureMessage;
      }

      // Report that the employee info was deleted successfully.
      return DeleteSuccessMessage;
    }

    #endregion
  }
}
