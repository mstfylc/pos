//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_table_type.g.dart';

class AssignmentTableType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'Pos')
  static const AssignmentTableType pos = _$pos;
  @BuiltValueEnumConst(wireName: r'Branch')
  static const AssignmentTableType branch = _$branch;
  @BuiltValueEnumConst(wireName: r'Store')
  static const AssignmentTableType store = _$store;

  static Serializer<AssignmentTableType> get serializer => _$assignmentTableTypeSerializer;

  const AssignmentTableType._(String name): super(name);

  static BuiltSet<AssignmentTableType> get values => _$values;
  static AssignmentTableType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class AssignmentTableTypeMixin = Object with _$AssignmentTableTypeMixin;

