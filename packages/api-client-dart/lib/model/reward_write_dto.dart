//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'reward_write_dto.g.dart';

abstract class RewardWriteDto implements Built<RewardWriteDto, RewardWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'pointCost')
    int get pointCost;

    @BuiltValueField(wireName: r'rewardType')
    int get rewardType;

    @nullable
    @BuiltValueField(wireName: r'discountAmount')
    double get discountAmount;

    @nullable
    @BuiltValueField(wireName: r'image')
    String get image;

    @nullable
    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'active')
    bool get active;

    RewardWriteDto._();

    static void _initializeBuilder(RewardWriteDtoBuilder b) => b;

    factory RewardWriteDto([void updates(RewardWriteDtoBuilder b)]) = _$RewardWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<RewardWriteDto> get serializer => _$RewardWriteDtoSerializer();
}

class _$RewardWriteDtoSerializer implements StructuredSerializer<RewardWriteDto> {

    @override
    final Iterable<Type> types = const [RewardWriteDto, _$RewardWriteDto];
    @override
    final String wireName = r'RewardWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, RewardWriteDto object,
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
            ..add(r'pointCost')
            ..add(serializers.serialize(object.pointCost,
                specifiedType: const FullType(int)));
        result
            ..add(r'rewardType')
            ..add(serializers.serialize(object.rewardType,
                specifiedType: const FullType(int)));
        result
            ..add(r'discountAmount')
            ..add(object.discountAmount == null ? null : serializers.serialize(object.discountAmount,
                specifiedType: const FullType(double)));
        result
            ..add(r'image')
            ..add(object.image == null ? null : serializers.serialize(object.image,
                specifiedType: const FullType(String)));
        result
            ..add(r'productId')
            ..add(object.productId == null ? null : serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    RewardWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RewardWriteDtoBuilder();

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
                case r'pointCost':
                    result.pointCost = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'rewardType':
                    result.rewardType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'discountAmount':
                    result.discountAmount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'image':
                    result.image = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
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

