//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'wallet_account_dto.g.dart';

abstract class WalletAccountDto implements Built<WalletAccountDto, WalletAccountDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'currency')
    String get currency;

    @BuiltValueField(wireName: r'balance')
    double get balance;

    WalletAccountDto._();

    static void _initializeBuilder(WalletAccountDtoBuilder b) => b;

    factory WalletAccountDto([void updates(WalletAccountDtoBuilder b)]) = _$WalletAccountDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<WalletAccountDto> get serializer => _$WalletAccountDtoSerializer();
}

class _$WalletAccountDtoSerializer implements StructuredSerializer<WalletAccountDto> {

    @override
    final Iterable<Type> types = const [WalletAccountDto, _$WalletAccountDto];
    @override
    final String wireName = r'WalletAccountDto';

    @override
    Iterable<Object> serialize(Serializers serializers, WalletAccountDto object,
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
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'currency')
            ..add(serializers.serialize(object.currency,
                specifiedType: const FullType(String)));
        result
            ..add(r'balance')
            ..add(serializers.serialize(object.balance,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    WalletAccountDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = WalletAccountDtoBuilder();

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
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'currency':
                    result.currency = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'balance':
                    result.balance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

