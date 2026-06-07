//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'wallet_account.g.dart';

abstract class WalletAccount implements Built<WalletAccount, WalletAccountBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'currency')
    String get currency;

    @BuiltValueField(wireName: r'balance')
    double get balance;

    WalletAccount._();

    static void _initializeBuilder(WalletAccountBuilder b) => b;

    factory WalletAccount([void updates(WalletAccountBuilder b)]) = _$WalletAccount;

    @BuiltValueSerializer(custom: true)
    static Serializer<WalletAccount> get serializer => _$WalletAccountSerializer();
}

class _$WalletAccountSerializer implements StructuredSerializer<WalletAccount> {

    @override
    final Iterable<Type> types = const [WalletAccount, _$WalletAccount];
    @override
    final String wireName = r'WalletAccount';

    @override
    Iterable<Object> serialize(Serializers serializers, WalletAccount object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
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
    WalletAccount deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = WalletAccountBuilder();

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

