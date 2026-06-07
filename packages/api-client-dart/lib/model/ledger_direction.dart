//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'ledger_direction.g.dart';

class LedgerDirection extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Debit')
  static const LedgerDirection debit = _$debit;
  @BuiltValueEnumConst(wireName: r'Credit')
  static const LedgerDirection credit = _$credit;

  static Serializer<LedgerDirection> get serializer => _$ledgerDirectionSerializer;

  const LedgerDirection._(String name): super(name);

  static BuiltSet<LedgerDirection> get values => _$values;
  static LedgerDirection valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class LedgerDirectionMixin = Object with _$LedgerDirectionMixin;

