using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [GestionVolume] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.GestionVolume_Collection"/> class to do so.
	/// </summary>
	public sealed class GestionVolume_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the GestionVolume_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.GestionVolume_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public GestionVolume_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public GestionVolume_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "GestionVolume", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_DateLivraisonWasSet = false;
		private bool col_DateLivraisonWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateLivraison {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateLivraison);
			}
			set {
			
				this.col_DateLivraisonWasUpdated = true;
				this.col_DateLivraisonWasSet = true;
				this.col_DateLivraison = value;
			}
		}

		internal bool col_UsineIDWasSet = false;
		private bool col_UsineIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UsineID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UsineID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsineID);
			}
			set {
			
				this.col_UsineIDWasUpdated = true;
				this.col_UsineIDWasSet = true;
				this.col_UsineID_Record = null;
				this.col_UsineID = value;
			}
		}

		
		private Usine_Record col_UsineID_Record = null;
		public Usine_Record Col_UsineID_Usine_Record {
		
			get {

				if (this.col_UsineID_Record == null) {
				
					this.col_UsineID_Record = new Usine_Record(this.connectionString, this.col_UsineID);
				}
				
				return(this.col_UsineID_Record);
			}
		}

		internal bool col_UniteMesureIDWasSet = false;
		private bool col_UniteMesureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteMesureID);
			}
			set {
			
				this.col_UniteMesureIDWasUpdated = true;
				this.col_UniteMesureIDWasSet = true;
				this.col_UniteMesureID_Record = null;
				this.col_UniteMesureID = value;
			}
		}

		
		private UniteMesure_Record col_UniteMesureID_Record = null;
		public UniteMesure_Record Col_UniteMesureID_UniteMesure_Record {
		
			get {

				if (this.col_UniteMesureID_Record == null) {
				
					this.col_UniteMesureID_Record = new UniteMesure_Record(this.connectionString, this.col_UniteMesureID);
				}
				
				return(this.col_UniteMesureID_Record);
			}
		}

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID_Record = null;
				this.col_ProducteurID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee = value;
			}
		}

		internal bool col_PeriodeWasSet = false;
		private bool col_PeriodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Periode = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Periode);
			}
			set {
			
				this.col_PeriodeWasUpdated = true;
				this.col_PeriodeWasSet = true;
				this.col_Periode = value;
			}
		}

		internal bool col_LotIDWasSet = false;
		private bool col_LotIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LotID);
			}
			set {
			
				this.col_LotIDWasUpdated = true;
				this.col_LotIDWasSet = true;
				this.col_LotID_Record = null;
				this.col_LotID = value;
			}
		}

		
		private Lot_Record col_LotID_Record = null;
		public Lot_Record Col_LotID_Lot_Record {
		
			get {

				if (this.col_LotID_Record == null) {
				
					this.col_LotID_Record = new Lot_Record(this.connectionString, this.col_LotID);
				}
				
				return(this.col_LotID_Record);
			}
		}

		internal bool col_DateEntreeWasSet = false;
		private bool col_DateEntreeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateEntree = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateEntree {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateEntree);
			}
			set {
			
				this.col_DateEntreeWasUpdated = true;
				this.col_DateEntreeWasSet = true;
				this.col_DateEntree = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DateLivraisonWasUpdated = false;
			this.col_DateLivraisonWasSet = false;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_UsineIDWasUpdated = false;
			this.col_UsineIDWasSet = false;
			this.col_UsineID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeWasUpdated = false;
			this.col_PeriodeWasSet = false;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;

			this.col_LotIDWasUpdated = false;
			this.col_LotIDWasSet = false;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_DateEntreeWasUpdated = false;
			this.col_DateEntreeWasSet = false;
			this.col_DateEntree = System.Data.SqlTypes.SqlDateTime.Null;

			Params.spS_GestionVolume Param = new Params.spS_GestionVolume(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_GestionVolume Sp = new SPs.spS_GestionVolume();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = sqlDataReader.GetSqlDateTime(SPs.spS_GestionVolume.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_UsineID.ColumnIndex)) {

						this.col_UsineID = sqlDataReader.GetSqlString(SPs.spS_GestionVolume.Resultset1.Fields.Column_UsineID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_GestionVolume.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_GestionVolume.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_GestionVolume.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = sqlDataReader.GetSqlInt32(SPs.spS_GestionVolume.Resultset1.Fields.Column_Periode.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = sqlDataReader.GetSqlInt32(SPs.spS_GestionVolume.Resultset1.Fields.Column_LotID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume.Resultset1.Fields.Column_DateEntree.ColumnIndex)) {

						this.col_DateEntree = sqlDataReader.GetSqlDateTime(SPs.spS_GestionVolume.Resultset1.Fields.Column_DateEntree.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateLivraisonWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsineIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateEntreeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_GestionVolume Param = new Params.spU_GestionVolume(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DateLivraisonWasUpdated) {

				Param.Param_DateLivraison = this.col_DateLivraison;
				Param.Param_ConsiderNull_DateLivraison = true;
			}

			if (this.col_UsineIDWasUpdated) {

				Param.Param_UsineID = this.col_UsineID;
				Param.Param_ConsiderNull_UsineID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_PeriodeWasUpdated) {

				Param.Param_Periode = this.col_Periode;
				Param.Param_ConsiderNull_Periode = true;
			}

			if (this.col_LotIDWasUpdated) {

				Param.Param_LotID = this.col_LotID;
				Param.Param_ConsiderNull_LotID = true;
			}

			if (this.col_DateEntreeWasUpdated) {

				Param.Param_DateEntree = this.col_DateEntree;
				Param.Param_ConsiderNull_DateEntree = true;
			}

			SPs.spU_GestionVolume Sp = new SPs.spU_GestionVolume();
			if (Sp.Execute(ref Param)) {

				this.col_DateLivraisonWasUpdated = false;
				this.col_UsineIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_PeriodeWasUpdated = false;
				this.col_LotIDWasUpdated = false;
				this.col_DateEntreeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Record", "Update");
			}		
		}

		private GestionVolume_Detail_Collection internal_GestionVolume_Detail_Col_GestionVolumeID_Collection = null;
		public GestionVolume_Detail_Collection GestionVolume_Detail_Col_GestionVolumeID_Collection {

			get {

				if (this.internal_GestionVolume_Detail_Col_GestionVolumeID_Collection == null) {

					this.internal_GestionVolume_Detail_Col_GestionVolumeID_Collection = new GestionVolume_Detail_Collection(this.connectionString);
					this.internal_GestionVolume_Detail_Col_GestionVolumeID_Collection.LoadFrom_GestionVolumeID(this.col_ID, this);
				}

				return(this.internal_GestionVolume_Detail_Col_GestionVolumeID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_GestionVolume_Display Param = new Params.spS_GestionVolume_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_GestionVolume_Display Sp = new SPs.spS_GestionVolume_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_GestionVolume_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_GestionVolume_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
