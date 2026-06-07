//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/address_dto.dart';
import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/wallet_account_dto.dart';
import 'package:mansis_pos_api_client/model/loyalty_account_dto.dart';
import 'package:mansis_pos_api_client/model/model_null.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_detail_dto.g.dart';

abstract class CustomerDetailDto implements Built<CustomerDetailDto, CustomerDetailDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'surname')
    String get surname;

    @BuiltValueField(wireName: r'username')
    String get username;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'balance')
    double get balance;

    @BuiltValueField(wireName: r'active')
    bool get active;

    @BuiltValueField(wireName: r'addresses')
    BuiltList<AddressDto> get addresses;

    @nullable
    @BuiltValueField(wireName: r'wallet')
    OneOfnullWalletAccountDto get wallet;

    @nullable
    @BuiltValueField(wireName: r'loyalty')
    OneOfnullLoyaltyAccountDto get loyalty;

    CustomerDetailDto._();

    static void _initializeBuilder(CustomerDetailDtoBuilder b) => b;

    factory CustomerDetailDto([void updates(CustomerDetailDtoBuilder b)]) = _$CustomerDetailDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerDetailDto> get serializer => _$CustomerDetailDtoSerializer();
}

class _$CustomerDetailDtoSerializer implements StructuredSerializer<CustomerDetailDto> {

    @override
    final Iterable<Type> types = const [CustomerDetailDto, _$CustomerDetailDto];
    @override
    final String wireName = r'CustomerDetailDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerDetailDto object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'surname')
            ..add(serializers.serialize(object.surname,
                specifiedType: const FullType(String)));
        result
            ..add(r'username')
            ..add(serializers.serialize(object.username,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(object.phone == null ? null : serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        result
            ..add(r'mail')
            ..add(object.mail == null ? null : serializers.serialize(object.mail,
                specifiedType: const FullType(String)));
        result
            ..add(r'balance')
            ..add(serializers.serialize(object.balance,
                specifiedType: const FullType(double)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        result
            ..add(r'addresses')
            ..add(serializers.serialize(object.addresses,
                specifiedType: const FullType(BuiltList, [FullType(AddressDto)])));
        result
            ..add(r'wallet')
            ..add(object.wallet == null ? null : serializers.serialize(object.wallet,
                specifiedType: const FullType(OneOfnullWalletAccountDto)));
        result
            ..add(r'loyalty')
            ..add(object.loyalty == null ? null : serializers.serialize(object.loyalty,
                specifiedType: const FullType(OneOfnullLoyaltyAccountDto)));
        return result;
    }

    @override
    CustomerDetailDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerDetailDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'surname':
                    result.surname = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'username':
                    result.username = serializers.deserialize(value,
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
                case r'balance':
                    result.balance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'addresses':
                    result.addresses.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(AddressDto)])) as BuiltList<AddressDto>);
                    break;
                case r'wallet':
                    result.wallet.replace(serializers.deserialize(value,
                        specifiedType: const FullType(OneOfnullWalletAccountDto)) as OneOfnullWalletAccountDto);
                    break;
                case r'loyalty':
                    result.loyalty.replace(serializers.deserialize(value,
                        specifiedType: const FullType(OneOfnullLoyaltyAccountDto)) as OneOfnullLoyaltyAccountDto);
                    break;
            }
        }
        return result.build();
    }
}

