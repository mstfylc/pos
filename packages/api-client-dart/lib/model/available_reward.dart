//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/reward_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'available_reward.g.dart';

abstract class AvailableReward implements Built<AvailableReward, AvailableRewardBuilder> {

    @BuiltValueField(wireName: r'rewardId')
    String get rewardId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'requiredPoints')
    int get requiredPoints;

    @BuiltValueField(wireName: r'rewardType')
    RewardType get rewardType;
    // enum rewardTypeEnum {  DiscountAmount,  FreeProduct,  Custom,  };

    @nullable
    @BuiltValueField(wireName: r'discountAmount')
    double get discountAmount;

    @nullable
    @BuiltValueField(wireName: r'productId')
    String get productId;

    AvailableReward._();

    static void _initializeBuilder(AvailableRewardBuilder b) => b;

    factory AvailableReward([void updates(AvailableRewardBuilder b)]) = _$AvailableReward;

    @BuiltValueSerializer(custom: true)
    static Serializer<AvailableReward> get serializer => _$AvailableRewardSerializer();
}

class _$AvailableRewardSerializer implements StructuredSerializer<AvailableReward> {

    @override
    final Iterable<Type> types = const [AvailableReward, _$AvailableReward];
    @override
    final String wireName = r'AvailableReward';

    @override
    Iterable<Object> serialize(Serializers serializers, AvailableReward object,
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
                specifiedType: const FullType(RewardType)));
        if (object.discountAmount != null) {
            result
                ..add(r'discountAmount')
                ..add(serializers.serialize(object.discountAmount,
                    specifiedType: const FullType(double)));
        }
        if (object.productId != null) {
            result
                ..add(r'productId')
                ..add(serializers.serialize(object.productId,
                    specifiedType: const FullType(String)));
        }
        return result;
    }

    @override
    AvailableReward deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AvailableRewardBuilder();

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
                        specifiedType: const FullType(RewardType)) as RewardType;
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

