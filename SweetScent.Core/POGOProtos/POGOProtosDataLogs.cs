// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: POGOProtos.Data.Logs.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace POGOProtos.Data.Logs {

  /// <summary>Holder for reflection information generated from POGOProtos.Data.Logs.proto</summary>
  public static partial class POGOProtosDataLogsReflection {

    #region Descriptor
    /// <summary>File descriptor for POGOProtos.Data.Logs.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static POGOProtosDataLogsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChpQT0dPUHJvdG9zLkRhdGEuTG9ncy5wcm90bxIUUE9HT1Byb3Rvcy5EYXRh",
            "LkxvZ3MaFlBPR09Qcm90b3MuRW51bXMucHJvdG8aGlBPR09Qcm90b3MuSW52",
            "ZW50b3J5LnByb3RvIsUBCg5BY3Rpb25Mb2dFbnRyeRIUCgx0aW1lc3RhbXBf",
            "bXMYASABKAMSDQoFc2ZpZGEYAiABKAgSQwoNY2F0Y2hfcG9rZW1vbhgDIAEo",
            "CzIqLlBPR09Qcm90b3MuRGF0YS5Mb2dzLkNhdGNoUG9rZW1vbkxvZ0VudHJ5",
            "SAASPwoLZm9ydF9zZWFyY2gYBCABKAsyKC5QT0dPUHJvdG9zLkRhdGEuTG9n",
            "cy5Gb3J0U2VhcmNoTG9nRW50cnlIAEIICgZBY3Rpb24i9wEKFENhdGNoUG9r",
            "ZW1vbkxvZ0VudHJ5EkEKBnJlc3VsdBgBIAEoDjIxLlBPR09Qcm90b3MuRGF0",
            "YS5Mb2dzLkNhdGNoUG9rZW1vbkxvZ0VudHJ5LlJlc3VsdBIvCgpwb2tlbW9u",
            "X2lkGAIgASgOMhsuUE9HT1Byb3Rvcy5FbnVtcy5Qb2tlbW9uSWQSFQoNY29t",
            "YmF0X3BvaW50cxgDIAEoBRIXCg9wb2tlbW9uX2RhdGFfaWQYBCABKAQiOwoG",
            "UmVzdWx0EgkKBVVOU0VUEAASFAoQUE9LRU1PTl9DQVBUVVJFRBABEhAKDFBP",
            "S0VNT05fRkxFRBACIsEBChJGb3J0U2VhcmNoTG9nRW50cnkSPwoGcmVzdWx0",
            "GAEgASgOMi8uUE9HT1Byb3Rvcy5EYXRhLkxvZ3MuRm9ydFNlYXJjaExvZ0Vu",
            "dHJ5LlJlc3VsdBIPCgdmb3J0X2lkGAIgASgJEikKBWl0ZW1zGAMgAygLMhou",
            "UE9HT1Byb3Rvcy5JbnZlbnRvcnkuSXRlbRIMCgRlZ2dzGAQgASgFIiAKBlJl",
            "c3VsdBIJCgVVTlNFVBAAEgsKB1NVQ0NFU1MQAVAAUAFiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::POGOProtos.Enums.POGOProtosEnumsReflection.Descriptor, global::POGOProtos.Inventory.POGOProtosInventoryReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::POGOProtos.Data.Logs.ActionLogEntry), global::POGOProtos.Data.Logs.ActionLogEntry.Parser, new[]{ "TimestampMs", "Sfida", "CatchPokemon", "FortSearch" }, new[]{ "Action" }, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::POGOProtos.Data.Logs.CatchPokemonLogEntry), global::POGOProtos.Data.Logs.CatchPokemonLogEntry.Parser, new[]{ "Result", "PokemonId", "CombatPoints", "PokemonDataId" }, null, new[]{ typeof(global::POGOProtos.Data.Logs.CatchPokemonLogEntry.Types.Result) }, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::POGOProtos.Data.Logs.FortSearchLogEntry), global::POGOProtos.Data.Logs.FortSearchLogEntry.Parser, new[]{ "Result", "FortId", "Items", "Eggs" }, null, new[]{ typeof(global::POGOProtos.Data.Logs.FortSearchLogEntry.Types.Result) }, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ActionLogEntry : pb::IMessage<ActionLogEntry> {
    private static readonly pb::MessageParser<ActionLogEntry> _parser = new pb::MessageParser<ActionLogEntry>(() => new ActionLogEntry());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ActionLogEntry> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::POGOProtos.Data.Logs.POGOProtosDataLogsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ActionLogEntry() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ActionLogEntry(ActionLogEntry other) : this() {
      timestampMs_ = other.timestampMs_;
      sfida_ = other.sfida_;
      switch (other.ActionCase) {
        case ActionOneofCase.CatchPokemon:
          CatchPokemon = other.CatchPokemon.Clone();
          break;
        case ActionOneofCase.FortSearch:
          FortSearch = other.FortSearch.Clone();
          break;
      }

    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ActionLogEntry Clone() {
      return new ActionLogEntry(this);
    }

    /// <summary>Field number for the "timestamp_ms" field.</summary>
    public const int TimestampMsFieldNumber = 1;
    private long timestampMs_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long TimestampMs {
      get { return timestampMs_; }
      set {
        timestampMs_ = value;
      }
    }

    /// <summary>Field number for the "sfida" field.</summary>
    public const int SfidaFieldNumber = 2;
    private bool sfida_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Sfida {
      get { return sfida_; }
      set {
        sfida_ = value;
      }
    }

    /// <summary>Field number for the "catch_pokemon" field.</summary>
    public const int CatchPokemonFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::POGOProtos.Data.Logs.CatchPokemonLogEntry CatchPokemon {
      get { return actionCase_ == ActionOneofCase.CatchPokemon ? (global::POGOProtos.Data.Logs.CatchPokemonLogEntry) action_ : null; }
      set {
        action_ = value;
        actionCase_ = value == null ? ActionOneofCase.None : ActionOneofCase.CatchPokemon;
      }
    }

    /// <summary>Field number for the "fort_search" field.</summary>
    public const int FortSearchFieldNumber = 4;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::POGOProtos.Data.Logs.FortSearchLogEntry FortSearch {
      get { return actionCase_ == ActionOneofCase.FortSearch ? (global::POGOProtos.Data.Logs.FortSearchLogEntry) action_ : null; }
      set {
        action_ = value;
        actionCase_ = value == null ? ActionOneofCase.None : ActionOneofCase.FortSearch;
      }
    }

    private object action_;
    /// <summary>Enum of possible cases for the "Action" oneof.</summary>
    public enum ActionOneofCase {
      None = 0,
      CatchPokemon = 3,
      FortSearch = 4,
    }
    private ActionOneofCase actionCase_ = ActionOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ActionOneofCase ActionCase {
      get { return actionCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearAction() {
      actionCase_ = ActionOneofCase.None;
      action_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ActionLogEntry);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ActionLogEntry other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TimestampMs != other.TimestampMs) return false;
      if (Sfida != other.Sfida) return false;
      if (!object.Equals(CatchPokemon, other.CatchPokemon)) return false;
      if (!object.Equals(FortSearch, other.FortSearch)) return false;
      if (ActionCase != other.ActionCase) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (TimestampMs != 0L) hash ^= TimestampMs.GetHashCode();
      if (Sfida != false) hash ^= Sfida.GetHashCode();
      if (actionCase_ == ActionOneofCase.CatchPokemon) hash ^= CatchPokemon.GetHashCode();
      if (actionCase_ == ActionOneofCase.FortSearch) hash ^= FortSearch.GetHashCode();
      hash ^= (int) actionCase_;
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (TimestampMs != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(TimestampMs);
      }
      if (Sfida != false) {
        output.WriteRawTag(16);
        output.WriteBool(Sfida);
      }
      if (actionCase_ == ActionOneofCase.CatchPokemon) {
        output.WriteRawTag(26);
        output.WriteMessage(CatchPokemon);
      }
      if (actionCase_ == ActionOneofCase.FortSearch) {
        output.WriteRawTag(34);
        output.WriteMessage(FortSearch);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (TimestampMs != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(TimestampMs);
      }
      if (Sfida != false) {
        size += 1 + 1;
      }
      if (actionCase_ == ActionOneofCase.CatchPokemon) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CatchPokemon);
      }
      if (actionCase_ == ActionOneofCase.FortSearch) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(FortSearch);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ActionLogEntry other) {
      if (other == null) {
        return;
      }
      if (other.TimestampMs != 0L) {
        TimestampMs = other.TimestampMs;
      }
      if (other.Sfida != false) {
        Sfida = other.Sfida;
      }
      switch (other.ActionCase) {
        case ActionOneofCase.CatchPokemon:
          CatchPokemon = other.CatchPokemon;
          break;
        case ActionOneofCase.FortSearch:
          FortSearch = other.FortSearch;
          break;
      }

    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            TimestampMs = input.ReadInt64();
            break;
          }
          case 16: {
            Sfida = input.ReadBool();
            break;
          }
          case 26: {
            global::POGOProtos.Data.Logs.CatchPokemonLogEntry subBuilder = new global::POGOProtos.Data.Logs.CatchPokemonLogEntry();
            if (actionCase_ == ActionOneofCase.CatchPokemon) {
              subBuilder.MergeFrom(CatchPokemon);
            }
            input.ReadMessage(subBuilder);
            CatchPokemon = subBuilder;
            break;
          }
          case 34: {
            global::POGOProtos.Data.Logs.FortSearchLogEntry subBuilder = new global::POGOProtos.Data.Logs.FortSearchLogEntry();
            if (actionCase_ == ActionOneofCase.FortSearch) {
              subBuilder.MergeFrom(FortSearch);
            }
            input.ReadMessage(subBuilder);
            FortSearch = subBuilder;
            break;
          }
        }
      }
    }

  }

  public sealed partial class CatchPokemonLogEntry : pb::IMessage<CatchPokemonLogEntry> {
    private static readonly pb::MessageParser<CatchPokemonLogEntry> _parser = new pb::MessageParser<CatchPokemonLogEntry>(() => new CatchPokemonLogEntry());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CatchPokemonLogEntry> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::POGOProtos.Data.Logs.POGOProtosDataLogsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatchPokemonLogEntry() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatchPokemonLogEntry(CatchPokemonLogEntry other) : this() {
      result_ = other.result_;
      pokemonId_ = other.pokemonId_;
      combatPoints_ = other.combatPoints_;
      pokemonDataId_ = other.pokemonDataId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatchPokemonLogEntry Clone() {
      return new CatchPokemonLogEntry(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private global::POGOProtos.Data.Logs.CatchPokemonLogEntry.Types.Result result_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::POGOProtos.Data.Logs.CatchPokemonLogEntry.Types.Result Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    /// <summary>Field number for the "pokemon_id" field.</summary>
    public const int PokemonIdFieldNumber = 2;
    private global::POGOProtos.Enums.PokemonId pokemonId_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::POGOProtos.Enums.PokemonId PokemonId {
      get { return pokemonId_; }
      set {
        pokemonId_ = value;
      }
    }

    /// <summary>Field number for the "combat_points" field.</summary>
    public const int CombatPointsFieldNumber = 3;
    private int combatPoints_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CombatPoints {
      get { return combatPoints_; }
      set {
        combatPoints_ = value;
      }
    }

    /// <summary>Field number for the "pokemon_data_id" field.</summary>
    public const int PokemonDataIdFieldNumber = 4;
    private ulong pokemonDataId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong PokemonDataId {
      get { return pokemonDataId_; }
      set {
        pokemonDataId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CatchPokemonLogEntry);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CatchPokemonLogEntry other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      if (PokemonId != other.PokemonId) return false;
      if (CombatPoints != other.CombatPoints) return false;
      if (PokemonDataId != other.PokemonDataId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0) hash ^= Result.GetHashCode();
      if (PokemonId != 0) hash ^= PokemonId.GetHashCode();
      if (CombatPoints != 0) hash ^= CombatPoints.GetHashCode();
      if (PokemonDataId != 0UL) hash ^= PokemonDataId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Result);
      }
      if (PokemonId != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) PokemonId);
      }
      if (CombatPoints != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(CombatPoints);
      }
      if (PokemonDataId != 0UL) {
        output.WriteRawTag(32);
        output.WriteUInt64(PokemonDataId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Result);
      }
      if (PokemonId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) PokemonId);
      }
      if (CombatPoints != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CombatPoints);
      }
      if (PokemonDataId != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(PokemonDataId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CatchPokemonLogEntry other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0) {
        Result = other.Result;
      }
      if (other.PokemonId != 0) {
        PokemonId = other.PokemonId;
      }
      if (other.CombatPoints != 0) {
        CombatPoints = other.CombatPoints;
      }
      if (other.PokemonDataId != 0UL) {
        PokemonDataId = other.PokemonDataId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            result_ = (global::POGOProtos.Data.Logs.CatchPokemonLogEntry.Types.Result) input.ReadEnum();
            break;
          }
          case 16: {
            pokemonId_ = (global::POGOProtos.Enums.PokemonId) input.ReadEnum();
            break;
          }
          case 24: {
            CombatPoints = input.ReadInt32();
            break;
          }
          case 32: {
            PokemonDataId = input.ReadUInt64();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the CatchPokemonLogEntry message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Result {
        [pbr::OriginalName("UNSET")] Unset = 0,
        [pbr::OriginalName("POKEMON_CAPTURED")] PokemonCaptured = 1,
        [pbr::OriginalName("POKEMON_FLED")] PokemonFled = 2,
      }

    }
    #endregion

  }

  public sealed partial class FortSearchLogEntry : pb::IMessage<FortSearchLogEntry> {
    private static readonly pb::MessageParser<FortSearchLogEntry> _parser = new pb::MessageParser<FortSearchLogEntry>(() => new FortSearchLogEntry());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FortSearchLogEntry> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::POGOProtos.Data.Logs.POGOProtosDataLogsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FortSearchLogEntry() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FortSearchLogEntry(FortSearchLogEntry other) : this() {
      result_ = other.result_;
      fortId_ = other.fortId_;
      items_ = other.items_.Clone();
      eggs_ = other.eggs_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FortSearchLogEntry Clone() {
      return new FortSearchLogEntry(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private global::POGOProtos.Data.Logs.FortSearchLogEntry.Types.Result result_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::POGOProtos.Data.Logs.FortSearchLogEntry.Types.Result Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    /// <summary>Field number for the "fort_id" field.</summary>
    public const int FortIdFieldNumber = 2;
    private string fortId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FortId {
      get { return fortId_; }
      set {
        fortId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::POGOProtos.Inventory.Item> _repeated_items_codec
        = pb::FieldCodec.ForMessage(26, global::POGOProtos.Inventory.Item.Parser);
    private readonly pbc::RepeatedField<global::POGOProtos.Inventory.Item> items_ = new pbc::RepeatedField<global::POGOProtos.Inventory.Item>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::POGOProtos.Inventory.Item> Items {
      get { return items_; }
    }

    /// <summary>Field number for the "eggs" field.</summary>
    public const int EggsFieldNumber = 4;
    private int eggs_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Eggs {
      get { return eggs_; }
      set {
        eggs_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FortSearchLogEntry);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FortSearchLogEntry other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      if (FortId != other.FortId) return false;
      if(!items_.Equals(other.items_)) return false;
      if (Eggs != other.Eggs) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0) hash ^= Result.GetHashCode();
      if (FortId.Length != 0) hash ^= FortId.GetHashCode();
      hash ^= items_.GetHashCode();
      if (Eggs != 0) hash ^= Eggs.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Result);
      }
      if (FortId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(FortId);
      }
      items_.WriteTo(output, _repeated_items_codec);
      if (Eggs != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Eggs);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Result);
      }
      if (FortId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FortId);
      }
      size += items_.CalculateSize(_repeated_items_codec);
      if (Eggs != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Eggs);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FortSearchLogEntry other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0) {
        Result = other.Result;
      }
      if (other.FortId.Length != 0) {
        FortId = other.FortId;
      }
      items_.Add(other.items_);
      if (other.Eggs != 0) {
        Eggs = other.Eggs;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            result_ = (global::POGOProtos.Data.Logs.FortSearchLogEntry.Types.Result) input.ReadEnum();
            break;
          }
          case 18: {
            FortId = input.ReadString();
            break;
          }
          case 26: {
            items_.AddEntriesFrom(input, _repeated_items_codec);
            break;
          }
          case 32: {
            Eggs = input.ReadInt32();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the FortSearchLogEntry message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Result {
        [pbr::OriginalName("UNSET")] Unset = 0,
        [pbr::OriginalName("SUCCESS")] Success = 1,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
