//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'earn_rule_scope.g.dart';

class EarnRuleScope extends EnumClass {

  @BuiltValueEnumConst(wireName: r'All')
  static const EarnRuleScope all = _$all;
  @BuiltValueEnumConst(wireName: r'Branch')
  static const EarnRuleScope branch = _$branch;
  @BuiltValueEnumConst(wireName: r'Category')
  static const EarnRuleScope category = _$category;

  static Serializer<EarnRuleScope> get serializer => _$earnRuleScopeSerializer;

  const EarnRuleScope._(String name): super(name);

  static BuiltSet<EarnRuleScope> get values => _$values;
  static EarnRuleScope valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class EarnRuleScopeMixin = Object with _$EarnRuleScopeMixin;

