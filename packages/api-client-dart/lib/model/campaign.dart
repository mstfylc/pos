//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/campaign_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'campaign.g.dart';

abstract class Campaign implements Built<Campaign, CampaignBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @BuiltValueField(wireName: r'campaignType')
    CampaignType get campaignType;
    // enum campaignTypeEnum {  ExtraPoints,  DiscountAmount,  Stamp,  };

    @BuiltValueField(wireName: r'ruleJson')
    String get ruleJson;

    @BuiltValueField(wireName: r'priority')
    int get priority;

    @nullable
    @BuiltValueField(wireName: r'maxTotalDiscount')
    double get maxTotalDiscount;

    @nullable
    @BuiltValueField(wireName: r'targetTierId')
    String get targetTierId;

    @nullable
    @BuiltValueField(wireName: r'startsAt')
    DateTime get startsAt;

    @nullable
    @BuiltValueField(wireName: r'endsAt')
    DateTime get endsAt;

    @BuiltValueField(wireName: r'active')
    bool get active;

    Campaign._();

    static void _initializeBuilder(CampaignBuilder b) => b;

    factory Campaign([void updates(CampaignBuilder b)]) = _$Campaign;

    @BuiltValueSerializer(custom: true)
    static Serializer<Campaign> get serializer => _$CampaignSerializer();
}

class _$CampaignSerializer implements StructuredSerializer<Campaign> {

    @override
    final Iterable<Type> types = const [Campaign, _$Campaign];
    @override
    final String wireName = r'Campaign';

    @override
    Iterable<Object> serialize(Serializers serializers, Campaign object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        if (object.description != null) {
            result
                ..add(r'description')
                ..add(serializers.serialize(object.description,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'campaignType')
            ..add(serializers.serialize(object.campaignType,
                specifiedType: const FullType(CampaignType)));
        result
            ..add(r'ruleJson')
            ..add(serializers.serialize(object.ruleJson,
                specifiedType: const FullType(String)));
        result
            ..add(r'priority')
            ..add(serializers.serialize(object.priority,
                specifiedType: const FullType(int)));
        if (object.maxTotalDiscount != null) {
            result
                ..add(r'maxTotalDiscount')
                ..add(serializers.serialize(object.maxTotalDiscount,
                    specifiedType: const FullType(double)));
        }
        if (object.targetTierId != null) {
            result
                ..add(r'targetTierId')
                ..add(serializers.serialize(object.targetTierId,
                    specifiedType: const FullType(String)));
        }
        if (object.startsAt != null) {
            result
                ..add(r'startsAt')
                ..add(serializers.serialize(object.startsAt,
                    specifiedType: const FullType(DateTime)));
        }
        if (object.endsAt != null) {
            result
                ..add(r'endsAt')
                ..add(serializers.serialize(object.endsAt,
                    specifiedType: const FullType(DateTime)));
        }
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    Campaign deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CampaignBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'campaignType':
                    result.campaignType = serializers.deserialize(value,
                        specifiedType: const FullType(CampaignType)) as CampaignType;
                    break;
                case r'ruleJson':
                    result.ruleJson = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'priority':
                    result.priority = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'maxTotalDiscount':
                    result.maxTotalDiscount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'targetTierId':
                    result.targetTierId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'startsAt':
                    result.startsAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'endsAt':
                    result.endsAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

