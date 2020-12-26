using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [MRCCorrection] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.MRCCorrection_Collection"/> class to do so.
	/// </summary>
	public sealed class MRCCorrection_Record : IBusinessComponentRecord {
	
		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the MRCCorrection_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.MRCCorrection_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public MRCCorrection_Record() {
		
		}
	
		public MRCCorrection_Record(string connectionString) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'MRCCorrection'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "MRCCorrection", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.connectionString = connectionString;
		}
		
		
		internal bool col_CodeMRCWasSet = false;
		internal System.Data.SqlTypes.SqlString col_CodeMRC = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CodeMRC {
		
			get {
			
				return(this.col_CodeMRC);
			}
		}

		internal bool col_CodeCIELWasSet = false;
		internal System.Data.SqlTypes.SqlString col_CodeCIEL = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CodeCIEL {
		
			get {
			
				return(this.col_CodeCIEL);
			}
		}


		public bool Refresh() {

			throw new System.Exception("Not available because this table has no primary key.");
		}

		public void Update() {

			throw new System.Exception("Not available because this table has no primary key.");

		}

		internal string displayName = null;
		public override string ToString() {

		
			if (this.displayName == null) {
			
				Params.spS_MRCCorrection_Display Param = new Params.spS_MRCCorrection_Display();
				Param.SetUpConnection(this.connectionString);


				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_MRCCorrection_Display Sp = new SPs.spS_MRCCorrection_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_MRCCorrection_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_MRCCorrection_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.MRCCorrection_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
