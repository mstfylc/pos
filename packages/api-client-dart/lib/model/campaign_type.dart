//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'campaign_type.g.dart';

class CampaignType extends EnumClass {

  @BuiltValueEnumConst(wireName: r'ExtraPoints')
  static const CampaignType extraPoints = _$extraPoints;
  @BuiltValueEnumConst(wireName: r'DiscountAmount')
  static const CampaignType discountAmount = _$discountAmount;
  @BuiltValueEnumConst(wireName: r'Stamp')
  static const CampaignType stamp = _$stamp;

  static Serializer<CampaignType> get serializer => _$campaignTypeSerializer;

  const CampaignType._(String name): super(name);

  static BuiltSet<CampaignType> get values => _$values;
  static CampaignType valueOf(String name) => _$valueOf(name);
}

/// Optionally, enum_class can generate a mixin to go with your enum for use
/// with Angular. It exposes your enum constants as getters. So, if you mix it
/// in to your Dart component class, the values become available to the
/// corresponding Angular template.
///
/// Trigger mixin generation by writing a line like this one next to your enum.
abstract class CampaignTypeMixin = Object with _$CampaignTypeMixin;

