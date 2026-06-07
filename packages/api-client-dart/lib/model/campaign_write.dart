//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/campaign_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'campaign_write.g.dart';

abstract class CampaignWrite implements Built<CampaignWrite, CampaignWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

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

    CampaignWrite._();

    static void _initializeBuilder(CampaignWriteBuilder b) => b;

    factory CampaignWrite([void updates(CampaignWriteBuilder b)]) = _$CampaignWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<CampaignWrite> get serializer => _$CampaignWriteSerializer();
}

class _$CampaignWriteSerializer implements StructuredSerializer<CampaignWrite> {

    @override
    final Iterable<Type> types = const [CampaignWrite, _$CampaignWrite];
    @override
    final String wireName = r'CampaignWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, CampaignWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
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
    CampaignWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CampaignWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
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

