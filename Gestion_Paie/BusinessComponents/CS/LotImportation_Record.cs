using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [LotImportation] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.LotImportation_Collection"/> class to do so.
	/// </summary>
	public sealed class LotImportation_Record : IBusinessComponentRecord {
	
		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the LotImportation_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.LotImportation_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public LotImportation_Record() {
		
		}
	
		public LotImportation_Record(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotImportation'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "LotImportation", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.connectionString = connectionString;
		}
		
		
		internal bool col_lo_code_cantonWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_canton = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_canton {
		
			get {
			
				return(this.col_lo_code_canton);
			}
		}

		internal bool col_lo_rangWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_rang = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_rang {
		
			get {
			
				return(this.col_lo_rang);
			}
		}

		internal bool col_lo_codeWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code {
		
			get {
			
				return(this.col_lo_code);
			}
		}

		internal bool col_lo_super_totWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_super_tot = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_super_tot {
		
			get {
			
				return(this.col_lo_super_tot);
			}
		}

		internal bool col_lo_super_boiseeWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_super_boisee = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_super_boisee {
		
			get {
			
				return(this.col_lo_super_boisee);
			}
		}

		internal bool col_lo_super_continWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_super_contin = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_super_contin {
		
			get {
			
				return(this.col_lo_super_contin);
			}
		}

		internal bool col_lo_code_fournisseurWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_fournisseur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_fournisseur {
		
			get {
			
				return(this.col_lo_code_fournisseur);
			}
		}

		internal bool col_lo_code_muniWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_muni = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_muni {
		
			get {
			
				return(this.col_lo_code_muni);
			}
		}

		internal bool col_lo_code_propWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_prop = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_prop {
		
			get {
			
				return(this.col_lo_code_prop);
			}
		}

		internal bool col_lo_code_contWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_cont = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_cont {
		
			get {
			
				return(this.col_lo_code_cont);
			}
		}

		internal bool col_lo_dateWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_date = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_date {
		
			get {
			
				return(this.col_lo_date);
			}
		}

		internal bool col_lo_code_deuxWasSet = false;
		internal System.Data.SqlTypes.SqlString col_lo_code_deux = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_lo_code_deux {
		
			get {
			
				return(this.col_lo_code_deux);
			}
		}

		internal bool col_TraiteWasSet = false;
		internal System.Data.SqlTypes.SqlBoolean col_Traite = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Traite {
		
			get {
			
				return(this.col_Traite);
			}
		}

		internal bool col_ValideWasSet = false;
		internal System.Data.SqlTypes.SqlBoolean col_Valide = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Valide {
		
			get {
			
				return(this.col_Valide);
			}
		}

		internal bool col_RaisonWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Raison = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Raison {
		
			get {
			
				return(this.col_Raison);
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
			
				Params.spS_LotImportation_Display Param = new Params.spS_LotImportation_Display();
				Param.SetUpConnection(this.connectionString);


				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_LotImportation_Display Sp = new SPs.spS_LotImportation_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_LotImportation_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_LotImportation_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotImportation_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
