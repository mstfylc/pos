//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/wallet_account_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'wallet_adjustment_dto.g.dart';

abstract class WalletAdjustmentDto implements Built<WalletAdjustmentDto, WalletAdjustmentDtoBuilder> {

    @BuiltValueField(wireName: r'account')
    WalletAccountDto get account;

    @BuiltValueField(wireName: r'transactionId')
    String get transactionId;

    WalletAdjustmentDto._();

    static void _initializeBuilder(WalletAdjustmentDtoBuilder b) => b;

    factory WalletAdjustmentDto([void updates(WalletAdjustmentDtoBuilder b)]) = _$WalletAdjustmentDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<WalletAdjustmentDto> get serializer => _$WalletAdjustmentDtoSerializer();
}

class _$WalletAdjustmentDtoSerializer implements StructuredSerializer<WalletAdjustmentDto> {

    @override
    final Iterable<Type> types = const [WalletAdjustmentDto, _$WalletAdjustmentDto];
    @override
    final String wireName = r'WalletAdjustmentDto';

    @override
    Iterable<Object> serialize(Serializers serializers, WalletAdjustmentDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'account')
            ..add(serializers.serialize(object.account,
                specifiedType: const FullType(WalletAccountDto)));
        result
            ..add(r'transactionId')
            ..add(serializers.serialize(object.transactionId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    WalletAdjustmentDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = WalletAdjustmentDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'account':
                    result.account.replace(serializers.deserialize(value,
                        specifiedType: const FullType(WalletAccountDto)) as WalletAccountDto);
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

