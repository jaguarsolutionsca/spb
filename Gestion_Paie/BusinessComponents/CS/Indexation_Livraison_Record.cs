using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Indexation_Livraison] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Indexation_Livraison_Collection"/> class to do so.
	/// </summary>
	public sealed class Indexation_Livraison_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Indexation_Livraison_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Indexation_Livraison_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Indexation_Livraison_Record() {
		
			this.recordWasLoadedFromDB = false;
		}
	
		/// <param name="col_IndexationID">[To be supplied.]</param>
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		public Indexation_Livraison_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_IndexationID, System.Data.SqlTypes.SqlInt32 col_LivraisonID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation_Livraison'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Indexation_Livraison", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.connectionString = connectionString;
			this.col_IndexationID = col_IndexationID;
			this.col_LivraisonID = col_LivraisonID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationID {
		
			get {
			
				return(this.col_IndexationID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_IndexationID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {
		
			get {
			
				return(this.col_LivraisonID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_LivraisonID = value;
				}
			}
		}
		

		public bool Refresh() {

			throw new System.Exception("Not available because this table has only primary keys and nothing else to refresh.");
		}

		public void Update() {

			throw new System.Exception("Not available because this table has only primary keys and nothing else to update.");

		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Indexation_Livraison_Display Param = new Params.spS_Indexation_Livraison_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_IndexationID = this.col_IndexationID;
				Param.Param_LivraisonID = this.col_LivraisonID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Indexation_Livraison_Display Sp = new SPs.spS_Indexation_Livraison_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Livraison_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Indexation_Livraison_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Livraison_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
