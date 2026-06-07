//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'ledger_entry_state.g.dart';

class LedgerEntryState extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Posted')
  static const LedgerEntryState posted = _$posted;
  @BuiltValueEnumConst(wireName: r'Reversed')
  static const LedgerEntryState reversed = _$reversed;

  static Serializer<LedgerEntryState> get serializer => _$ledgerEntryStateSerializer;

  const LedgerEntryState._(String name): super(name);

  static BuiltSet<LedgerEntryState> get values => _$values;
  static LedgerEntryState valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class LedgerEntryStateMixin = Object with _$LedgerEntryStateMixin;

