//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'redeem_reward_response.g.dart';

abstract class RedeemRewardResponse implements Built<RedeemRewardResponse, RedeemRewardResponseBuilder> {

    @BuiltValueField(wireName: r'redemptionId')
    String get redemptionId;

    @BuiltValueField(wireName: r'redemptionCode')
    String get redemptionCode;

    @BuiltValueField(wireName: r'loyaltyTransactionId')
    String get loyaltyTransactionId;

    @BuiltValueField(wireName: r'points')
    int get points;

    @BuiltValueField(wireName: r'pointBalance')
    int get pointBalance;

    @BuiltValueField(wireName: r'state')
    int get state;

    RedeemRewardResponse._();

    static void _initializeBuilder(RedeemRewardResponseBuilder b) => b;

    factory RedeemRewardResponse([void updates(RedeemRewardResponseBuilder b)]) = _$RedeemRewardResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<RedeemRewardResponse> get serializer => _$RedeemRewardResponseSerializer();
}

class _$RedeemRewardResponseSerializer implements StructuredSerializer<RedeemRewardResponse> {

    @override
    final Iterable<Type> types = const [RedeemRewardResponse, _$RedeemRewardResponse];
    @override
    final String wireName = r'RedeemRewardResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, RedeemRewardResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'redemptionId')
            ..add(serializers.serialize(object.redemptionId,
                specifiedType: const FullType(String)));
        result
            ..add(r'redemptionCode')
            ..add(serializers.serialize(object.redemptionCode,
                specifiedType: const FullType(String)));
        result
            ..add(r'loyaltyTransactionId')
            ..add(serializers.serialize(object.loyaltyTransactionId,
                specifiedType: const FullType(String)));
        result
            ..add(r'points')
            ..add(serializers.serialize(object.points,
                specifiedType: const FullType(int)));
        result
            ..add(r'pointBalance')
            ..add(serializers.serialize(object.pointBalance,
                specifiedType: const FullType(int)));
        result
            ..add(r'state')
            ..add(serializers.serialize(object.state,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    RedeemRewardResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RedeemRewardResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'redemptionId':
                    result.redemptionId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'redemptionCode':
                    result.redemptionCode = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'loyaltyTransactionId':
                    result.loyaltyTransactionId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'points':
                    result.points = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'pointBalance':
                    result.pointBalance = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'state':
                    result.state = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

