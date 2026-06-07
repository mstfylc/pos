//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'entry_tracking_mode.g.dart';

class EntryTrackingMode extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Manual')
  static const EntryTrackingMode manual = _$manual;
  @BuiltValueEnumConst(wireName: r'Auto')
  static const EntryTrackingMode auto = _$auto;

  static Serializer<EntryTrackingMode> get serializer => _$entryTrackingModeSerializer;

  const EntryTrackingMode._(String name): super(name);

  static BuiltSet<EntryTrackingMode> get values => _$values;
  static EntryTrackingMode valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class EntryTrackingModeMixin = Object with _$EntryTrackingModeMixin;

