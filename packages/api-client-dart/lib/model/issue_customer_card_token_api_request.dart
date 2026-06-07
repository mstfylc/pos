//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'issue_customer_card_token_api_request.g.dart';

abstract class IssueCustomerCardTokenApiRequest implements Built<IssueCustomerCardTokenApiRequest, IssueCustomerCardTokenApiRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'expiresInSeconds')
    int get expiresInSeconds;

    IssueCustomerCardTokenApiRequest._();

    static void _initializeBuilder(IssueCustomerCardTokenApiRequestBuilder b) => b
        ..expiresInSeconds = 300;

    factory IssueCustomerCardTokenApiRequest([void updates(IssueCustomerCardTokenApiRequestBuilder b)]) = _$IssueCustomerCardTokenApiRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<IssueCustomerCardTokenApiRequest> get serializer => _$IssueCustomerCardTokenApiRequestSerializer();
}

class _$IssueCustomerCardTokenApiRequestSerializer implements StructuredSerializer<IssueCustomerCardTokenApiRequest> {

    @override
    final Iterable<Type> types = const [IssueCustomerCardTokenApiRequest, _$IssueCustomerCardTokenApiRequest];
    @override
    final String wireName = r'IssueCustomerCardTokenApiRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, IssueCustomerCardTokenApiRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        if (object.expiresInSeconds != null) {
            result
                ..add(r'expiresInSeconds')
                ..add(serializers.serialize(object.expiresInSeconds,
                    specifiedType: const FullType(int)));
        }
        return result;
    }

    @override
    IssueCustomerCardTokenApiRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = IssueCustomerCardTokenApiRequestBuilder();

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
                case r'expiresInSeconds':
                    result.expiresInSeconds = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

