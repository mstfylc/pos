//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'identified_customer.g.dart';

abstract class IdentifiedCustomer implements Built<IdentifiedCustomer, IdentifiedCustomerBuilder> {

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'surname')
    String get surname;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'walletBalance')
    double get walletBalance;

    @BuiltValueField(wireName: r'pointBalance')
    int get pointBalance;

    @BuiltValueField(wireName: r'lifetimePoints')
    int get lifetimePoints;

    @nullable
    @BuiltValueField(wireName: r'tierId')
    String get tierId;

    @nullable
    @BuiltValueField(wireName: r'tierName')
    String get tierName;

    IdentifiedCustomer._();

    static void _initializeBuilder(IdentifiedCustomerBuilder b) => b;

    factory IdentifiedCustomer([void updates(IdentifiedCustomerBuilder b)]) = _$IdentifiedCustomer;

    @BuiltValueSerializer(custom: true)
    static Serializer<IdentifiedCustomer> get serializer => _$IdentifiedCustomerSerializer();
}

class _$IdentifiedCustomerSerializer implements StructuredSerializer<IdentifiedCustomer> {

    @override
    final Iterable<Type> types = const [IdentifiedCustomer, _$IdentifiedCustomer];
    @override
    final String wireName = r'IdentifiedCustomer';

    @override
    Iterable<Object> serialize(Serializers serializers, IdentifiedCustomer object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'surname')
            ..add(serializers.serialize(object.surname,
                specifiedType: const FullType(String)));
        if (object.phone != null) {
            result
                ..add(r'phone')
                ..add(serializers.serialize(object.phone,
                    specifiedType: const FullType(String)));
        }
        if (object.mail != null) {
            result
                ..add(r'mail')
                ..add(serializers.serialize(object.mail,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'walletBalance')
            ..add(serializers.serialize(object.walletBalance,
                specifiedType: const FullType(double)));
        result
            ..add(r'pointBalance')
            ..add(serializers.serialize(object.pointBalance,
                specifiedType: const FullType(int)));
        result
            ..add(r'lifetimePoints')
            ..add(serializers.serialize(object.lifetimePoints,
                specifiedType: const FullType(int)));
        if (object.tierId != null) {
            result
                ..add(r'tierId')
                ..add(serializers.serialize(object.tierId,
                    specifiedType: const FullType(String)));
        }
        if (object.tierName != null) {
            result
                ..add(r'tierName')
                ..add(serializers.serialize(object.tierName,
                    specifiedType: const FullType(String)));
        }
        return result;
    }

    @override
    IdentifiedCustomer deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = IdentifiedCustomerBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'surname':
                    result.surname = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'mail':
                    result.mail = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'walletBalance':
                    result.walletBalance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'pointBalance':
                    result.pointBalance = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'lifetimePoints':
                    result.lifetimePoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'tierId':
                    result.tierId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'tierName':
                    result.tierName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

