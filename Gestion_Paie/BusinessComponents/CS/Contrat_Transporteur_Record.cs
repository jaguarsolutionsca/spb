﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contrat_Transporteur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contrat_Transporteur_Collection"/> class to do so.
	/// </summary>
	public sealed class Contrat_Transporteur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contrat_Transporteur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contrat_Transporteur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contrat_Transporteur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		public Contrat_Transporteur_Record(string connectionString, System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_ZoneID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_Transporteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat_Transporteur", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ContratID = col_ContratID;
			this.col_UniteID = col_UniteID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_ZoneID = col_ZoneID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {
		
			get {
			
				return(this.col_ContratID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ContratID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {
		
			get {
			
				return(this.col_UniteID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_UniteID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {
		
			get {
			
				return(this.col_MunicipaliteID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_MunicipaliteID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {
		
			get {
			
				return(this.col_ZoneID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ZoneID = value;
				}
			}
		}
		
		
		private Contrat_Record col_ContratID_Record = null;
		public Contrat_Record Col_ContratID_Contrat_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_Record(this.connectionString, this.col_ContratID);
				}
				
				return(this.col_ContratID_Record);
			}
		}

		
		private UniteMesure_Record col_UniteID_Record = null;
		public UniteMesure_Record Col_UniteID_UniteMesure_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new UniteMesure_Record(this.connectionString, this.col_UniteID);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		
		private Municipalite_Zone_Record col_MunicipaliteID_Record = null;
		public Municipalite_Zone_Record Col_MunicipaliteID_Municipalite_Zone_Record {
		
			get {

				if (this.col_MunicipaliteID_Record == null) {
				
					this.col_MunicipaliteID_Record = new Municipalite_Zone_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_MunicipaliteID);
				}
				
				return(this.col_MunicipaliteID_Record);
			}
		}

		internal bool col_Taux_transporteurWasSet = false;
		private bool col_Taux_transporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux_transporteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux_transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_transporteur);
			}
			set {
			
				this.col_Taux_transporteurWasUpdated = true;
				this.col_Taux_transporteurWasSet = true;
				this.col_Taux_transporteur = value;
			}
		}

		internal bool col_Taux_producteurWasSet = false;
		private bool col_Taux_producteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux_producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_producteur);
			}
			set {
			
				this.col_Taux_producteurWasUpdated = true;
				this.col_Taux_producteurWasSet = true;
				this.col_Taux_producteur = value;
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}

		
		private Municipalite_Zone_Record col_ZoneID_Record = null;
		public Municipalite_Zone_Record Col_ZoneID_Municipalite_Zone_Record {
		
			get {

				if (this.col_ZoneID_Record == null) {
				
					this.col_ZoneID_Record = new Municipalite_Zone_Record(this.connectionString, this.col_ZoneID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_ZoneID_Record);
			}
		}


		public bool Refresh() {

			this.displayName = null;



			this.col_Taux_transporteurWasUpdated = false;
			this.col_Taux_transporteurWasSet = false;
			this.col_Taux_transporteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Taux_producteurWasUpdated = false;
			this.col_Taux_producteurWasSet = false;
			this.col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;


			Params.spS_Contrat_Transporteur Param = new Params.spS_Contrat_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contrat_Transporteur Sp = new SPs.spS_Contrat_Transporteur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_transporteur.ColumnIndex)) {

						this.col_Taux_transporteur = sqlDataReader.GetSqlSingle(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_producteur.ColumnIndex)) {

						this.col_Taux_producteur = sqlDataReader.GetSqlSingle(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Taux_producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat_Transporteur.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Transporteur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_transporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_producteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contrat_Transporteur Param = new Params.spU_Contrat_Transporteur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ContratID = this.col_ContratID;
			Param.Param_UniteID = this.col_UniteID;
			Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			Param.Param_ZoneID = this.col_ZoneID;

			if (this.col_Taux_transporteurWasUpdated) {

				Param.Param_Taux_transporteur = this.col_Taux_transporteur;
				Param.Param_ConsiderNull_Taux_transporteur = true;
			}

			if (this.col_Taux_producteurWasUpdated) {

				Param.Param_Taux_producteur = this.col_Taux_producteur;
				Param.Param_ConsiderNull_Taux_producteur = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Contrat_Transporteur Sp = new SPs.spU_Contrat_Transporteur();
			if (Sp.Execute(ref Param)) {

				this.col_Taux_transporteurWasUpdated = false;
				this.col_Taux_producteurWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Transporteur_Record", "Update");
			}		
		}

		private Ajustement_Transporteur_Collection internal_Ajustement_Transporteur_Col_UniteID_Collection = null;
		public Ajustement_Transporteur_Collection Ajustement_Transporteur_Col_UniteID_Collection {

			get {

				if (this.internal_Ajustement_Transporteur_Col_UniteID_Collection == null) {

					this.internal_Ajustement_Transporteur_Col_UniteID_Collection = new Ajustement_Transporteur_Collection(this.connectionString);
					this.internal_Ajustement_Transporteur_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_Ajustement_Transporteur_Col_UniteID_Collection);
			}
		}

		private Ajustement_Transporteur_Collection internal_Ajustement_Transporteur_Col_MunicipaliteID_Collection = null;
		public Ajustement_Transporteur_Collection Ajustement_Transporteur_Col_MunicipaliteID_Collection {

			get {

				if (this.internal_Ajustement_Transporteur_Col_MunicipaliteID_Collection == null) {

					this.internal_Ajustement_Transporteur_Col_MunicipaliteID_Collection = new Ajustement_Transporteur_Collection(this.connectionString);
					this.internal_Ajustement_Transporteur_Col_MunicipaliteID_Collection.LoadFrom_MunicipaliteID(this.col_MunicipaliteID, this);
				}

				return(this.internal_Ajustement_Transporteur_Col_MunicipaliteID_Collection);
			}
		}

		private Ajustement_Transporteur_Collection internal_Ajustement_Transporteur_Col_ContratID_Collection = null;
		public Ajustement_Transporteur_Collection Ajustement_Transporteur_Col_ContratID_Collection {

			get {

				if (this.internal_Ajustement_Transporteur_Col_ContratID_Collection == null) {

					this.internal_Ajustement_Transporteur_Col_ContratID_Collection = new Ajustement_Transporteur_Collection(this.connectionString);
					this.internal_Ajustement_Transporteur_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ContratID, this);
				}

				return(this.internal_Ajustement_Transporteur_Col_ContratID_Collection);
			}
		}

		private Ajustement_Transporteur_Collection internal_Ajustement_Transporteur_Col_ZoneID_Collection = null;
		public Ajustement_Transporteur_Collection Ajustement_Transporteur_Col_ZoneID_Collection {

			get {

				if (this.internal_Ajustement_Transporteur_Col_ZoneID_Collection == null) {

					this.internal_Ajustement_Transporteur_Col_ZoneID_Collection = new Ajustement_Transporteur_Collection(this.connectionString);
					this.internal_Ajustement_Transporteur_Col_ZoneID_Collection.LoadFrom_ZoneID(this.col_ZoneID, this);
				}

				return(this.internal_Ajustement_Transporteur_Col_ZoneID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contrat_Transporteur_Display Param = new Params.spS_Contrat_Transporteur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_UniteID = this.col_UniteID;
				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ZoneID = this.col_ZoneID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contrat_Transporteur_Display Sp = new SPs.spS_Contrat_Transporteur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_Transporteur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contrat_Transporteur_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Transporteur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
