//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/loyalty_account_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_adjustment_dto.g.dart';

abstract class LoyaltyAdjustmentDto implements Built<LoyaltyAdjustmentDto, LoyaltyAdjustmentDtoBuilder> {

    @BuiltValueField(wireName: r'account')
    LoyaltyAccountDto get account;

    @BuiltValueField(wireName: r'transactionId')
    String get transactionId;

    LoyaltyAdjustmentDto._();

    static void _initializeBuilder(LoyaltyAdjustmentDtoBuilder b) => b;

    factory LoyaltyAdjustmentDto([void updates(LoyaltyAdjustmentDtoBuilder b)]) = _$LoyaltyAdjustmentDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyAdjustmentDto> get serializer => _$LoyaltyAdjustmentDtoSerializer();
}

class _$LoyaltyAdjustmentDtoSerializer implements StructuredSerializer<LoyaltyAdjustmentDto> {

    @override
    final Iterable<Type> types = const [LoyaltyAdjustmentDto, _$LoyaltyAdjustmentDto];
    @override
    final String wireName = r'LoyaltyAdjustmentDto';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyAdjustmentDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'account')
            ..add(serializers.serialize(object.account,
                specifiedType: const FullType(LoyaltyAccountDto)));
        result
            ..add(r'transactionId')
            ..add(serializers.serialize(object.transactionId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    LoyaltyAdjustmentDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyAdjustmentDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'account':
                    result.account.replace(serializers.deserialize(value,
                        specifiedType: const FullType(LoyaltyAccountDto)) as LoyaltyAccountDto);
                    break;
                case r'transactionId':
                    result.transactionId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

