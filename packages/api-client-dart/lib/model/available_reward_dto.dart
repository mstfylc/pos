//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'available_reward_dto.g.dart';

abstract class AvailableRewardDto implements Built<AvailableRewardDto, AvailableRewardDtoBuilder> {

    @BuiltValueField(wireName: r'rewardId')
    String get rewardId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'requiredPoints')
    int get requiredPoints;

    @BuiltValueField(wireName: r'rewardType')
    int get rewardType;

    @nullable
    @BuiltValueField(wireName: r'discountAmount')
    double get discountAmount;

    @nullable
    @BuiltValueField(wireName: r'productId')
    String get productId;

    AvailableRewardDto._();

    static void _initializeBuilder(AvailableRewardDtoBuilder b) => b;

    factory AvailableRewardDto([void updates(AvailableRewardDtoBuilder b)]) = _$AvailableRewardDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<AvailableRewardDto> get serializer => _$AvailableRewardDtoSerializer();
}

class _$AvailableRewardDtoSerializer implements StructuredSerializer<AvailableRewardDto> {

    @override
    final Iterable<Type> types = const [AvailableRewardDto, _$AvailableRewardDto];
    @override
    final String wireName = r'AvailableRewardDto';

    @override
    Iterable<Object> serialize(Serializers serializers, AvailableRewardDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'rewardId')
            ..add(serializers.serialize(object.rewardId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'requiredPoints')
            ..add(serializers.serialize(object.requiredPoints,
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
            ..add(r'productId')
            ..add(object.productId == null ? null : serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    AvailableRewardDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AvailableRewardDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'rewardId':
                    result.rewardId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'requiredPoints':
                    result.requiredPoints = serializers.deserialize(value,
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
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

