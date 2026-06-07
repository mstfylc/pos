//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'campaign_write_dto.g.dart';

abstract class CampaignWriteDto implements Built<CampaignWriteDto, CampaignWriteDtoBuilder> {

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
    int get campaignType;

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

    CampaignWriteDto._();

    static void _initializeBuilder(CampaignWriteDtoBuilder b) => b;

    factory CampaignWriteDto([void updates(CampaignWriteDtoBuilder b)]) = _$CampaignWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CampaignWriteDto> get serializer => _$CampaignWriteDtoSerializer();
}

class _$CampaignWriteDtoSerializer implements StructuredSerializer<CampaignWriteDto> {

    @override
    final Iterable<Type> types = const [CampaignWriteDto, _$CampaignWriteDto];
    @override
    final String wireName = r'CampaignWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CampaignWriteDto object,
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
        result
            ..add(r'description')
            ..add(object.description == null ? null : serializers.serialize(object.description,
                specifiedType: const FullType(String)));
        result
            ..add(r'campaignType')
            ..add(serializers.serialize(object.campaignType,
                specifiedType: const FullType(int)));
        result
            ..add(r'ruleJson')
            ..add(serializers.serialize(object.ruleJson,
                specifiedType: const FullType(String)));
        result
            ..add(r'priority')
            ..add(serializers.serialize(object.priority,
                specifiedType: const FullType(int)));
        result
            ..add(r'maxTotalDiscount')
            ..add(object.maxTotalDiscount == null ? null : serializers.serialize(object.maxTotalDiscount,
                specifiedType: const FullType(double)));
        result
            ..add(r'targetTierId')
            ..add(object.targetTierId == null ? null : serializers.serialize(object.targetTierId,
                specifiedType: const FullType(String)));
        result
            ..add(r'startsAt')
            ..add(object.startsAt == null ? null : serializers.serialize(object.startsAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'endsAt')
            ..add(object.endsAt == null ? null : serializers.serialize(object.endsAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    CampaignWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CampaignWriteDtoBuilder();

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
                        specifiedType: const FullType(int)) as int;
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

