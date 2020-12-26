using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Periode] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Periode {

		Params.spS_Periode Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Periode class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Periode(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Periode'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Periode", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Periode(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Periode class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Periode(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlConnection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlConnection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Periode'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Periode", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Periode(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Periode class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Periode(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlTransaction.Connection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlTransaction.Connection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlTransaction.Connection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Periode'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Periode", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Periode(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_Annee;
		/// <summary>
		/// Returns the value of the Annee column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Annee&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_Annee {

			get {

				return (this.col_Annee);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_SemaineNo;
		/// <summary>
		/// Returns the value of the SemaineNo column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;SemaineNo&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_SemaineNo {

			get {

				return (this.col_SemaineNo);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateDebut;
		/// <summary>
		/// Returns the value of the DateDebut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateDebut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateDebut {

			get {

				return (this.col_DateDebut);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateFin;
		/// <summary>
		/// Returns the value of the DateFin column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateFin&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateFin {

			get {

				return (this.col_DateFin);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_PeriodeContingentement;
		/// <summary>
		/// Returns the value of the PeriodeContingentement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PeriodeContingentement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeContingentement {

			get {

				return (this.col_PeriodeContingentement);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.col_SemaineNo = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Periode] table.
		/// </summary>
		/// <param name="col_Annee">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Annee&quot; column.</param>
		/// <param name="col_SemaineNo">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;SemaineNo&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlInt32 col_SemaineNo) {

			bool Status;
			Reset();

			if (col_Annee.IsNull) {

				throw new ArgumentNullException("col_Annee" , "The primary key 'col_Annee' can not have a Null value!");
			}

			if (col_SemaineNo.IsNull) {

				throw new ArgumentNullException("col_SemaineNo" , "The primary key 'col_SemaineNo' can not have a Null value!");
			}


			this.col_Annee = col_Annee;
			this.col_SemaineNo = col_SemaineNo;

			this.Param.Reset();

			this.Param.Param_Annee = this.col_Annee;
			this.Param.Param_SemaineNo = this.col_SemaineNo;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Periode SP = new SPs.spS_Periode(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_DateDebut.ColumnIndex)) {

						this.col_DateDebut = DR.GetSqlDateTime(SPs.spS_Periode.Resultset1.Fields.Column_DateDebut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_DateFin.ColumnIndex)) {

						this.col_DateFin = DR.GetSqlDateTime(SPs.spS_Periode.Resultset1.Fields.Column_DateFin.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex)) {

						this.col_PeriodeContingentement = DR.GetSqlInt32(SPs.spS_Periode.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex);
					}

					Status = true;
				}

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				return(Status);
			}

			else {

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Periode", "Refresh");
			}
		}
	}
}
