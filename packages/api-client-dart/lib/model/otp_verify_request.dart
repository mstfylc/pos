//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'otp_verify_request.g.dart';

abstract class OtpVerifyRequest implements Built<OtpVerifyRequest, OtpVerifyRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'phone')
    String get phone;

    @BuiltValueField(wireName: r'code')
    String get code;

    OtpVerifyRequest._();

    static void _initializeBuilder(OtpVerifyRequestBuilder b) => b;

    factory OtpVerifyRequest([void updates(OtpVerifyRequestBuilder b)]) = _$OtpVerifyRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<OtpVerifyRequest> get serializer => _$OtpVerifyRequestSerializer();
}

class _$OtpVerifyRequestSerializer implements StructuredSerializer<OtpVerifyRequest> {

    @override
    final Iterable<Type> types = const [OtpVerifyRequest, _$OtpVerifyRequest];
    @override
    final String wireName = r'OtpVerifyRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, OtpVerifyRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        result
            ..add(r'code')
            ..add(serializers.serialize(object.code,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    OtpVerifyRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OtpVerifyRequestBuilder();

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
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'code':
                    result.code = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

